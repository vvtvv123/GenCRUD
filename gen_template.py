#!/usr/bin/python3
#
# Using the file system load
#
# We now assume we have a template dir in the same dir
#
import argparse
import os
from jinja2 import Environment, FileSystemLoader

# Capture our current directory
THIS_DIR = os.path.dirname(os.path.abspath(__file__))

def parse_var(var_list):
    kv = str.split(var_list, ",")
    vars = {}
    mmap = {'str':'string', 'int':'int', 'dt': 'DateTime'}
    for k_v in kv:
        pair = str.split(k_v.strip(), " ")
        vars[pair[1].strip()] = mmap[pair[0].strip()] 
    print(vars)
    return vars

def parse_required(list):
    required = {}
    vars = str.split(list.strip(), ',')
    for var in vars:
        required[var.strip()] = 1
    print(required)
    return required

def parse_maxlen(lens):
    maxlen = {}
    kv = str.split(lens.strip(), ',')
    for k_v in kv:
        pair = str.split(k_v.strip(), " ")
        maxlen[pair[0].strip()] = pair[1].strip()
    print(maxlen)
    return maxlen

def parse_model(file):
    vars = {}
    maxlen = {}
    required = []
    model = ""

    # open file
    with open(file) as f:
        content = f.readlines()

    for line in content:
        if ":" in line:
            ss = str.split(line.rstrip("\r\n"), ":")
            if ss[0] == "model":
                model = ss[1]
            if ss[0] == "vars":
                vars = parse_var(ss[1])
            if ss[0] == 'required':
                required = parse_required(ss[1])
            if ss[0] == 'maxlen':
                maxlen = parse_maxlen(ss[1])
   
    return model, vars, maxlen, required

def gen_model(j2_env, model, vars, maxlen, required, project, filename):
    return j2_env.get_template(filename).render(project = project,
        model = model,
        model_lower = model.lower(),
        maxlen = maxlen,
        vars = vars,
        required = required)

def check_dir(path):
    if not os.path.exists(path):
        raise Exception

def touch_file(string, path, file):
    new_file = os.path.join(path, file)    
    if not os.path.exists(path):
        os.makedirs(path)
    with open(new_file, 'wb') as f:
        content = f.write(string.encode("utf-8"))
    print("write %s" % new_file)

if __name__ == '__main__':

    parser = argparse.ArgumentParser(description='Generate asp.net code for a model')
    
    parser.add_argument("-f", help='model description file', dest="model", required=True)
    parser.add_argument("-p", help='project name', dest="project", required=True)
    parser.add_argument("-d", help='destination directory', dest="path", required=True)
    args = parser.parse_args()
    print(args.path)

    # Create the jinja2 environment.
    j2_env = Environment(loader=FileSystemLoader(THIS_DIR + "/template"),
                         trim_blocks=True)

    project = args.project
    model, vars, maxlen, required = parse_model(args.model)

    # file map, for GRUD, this reflects the basic code we have to create
    file_map = {
        '.Core': ['Client.cs', 'IClientManager.cs', 'ClientManager.cs'],
        '.Application': ['ClientAppService.cs', 'IClientAppService.cs']
    }

    special = {
        '.Application\\' + model + 's\\Dtos': ['CreateClientInput.cs', 'CreateClientOutput.cs', 'GetAllClientsItem.cs',
                              'GetAllClientsOutput.cs', 'GetClientByIdOutput.cs', 'UpdateClientInput.cs',
                              'UpdateClientOutput.cs'],
        '.Web.Mvc\\Controllers': ['ClientsController.cs'],
        '.Web.Mvc\\Models\\' + model + 's': ['ClientViewModel.cs', 'ClientListViewModel.cs'],
        '.Web.Mvc\\Views\\' + model + 's': ['Create.cshtml', 'Delete.cshtml', 'Edit.cshtml', 'Index.cshtml']
    }

    for dir in file_map:
        path = os.path.join(args.path, args.project + dir, model + "s")
        print(path)
        check_dir(os.path.join(args.path, args.project + dir))
        for ff in file_map[dir]:
            content = gen_model(j2_env, model, vars, maxlen, required, project, ff)
            touch_file(content, path, str.replace(ff, 'Client', model))

    for dir in special:
        path = os.path.join(args.path, args.project + dir)
        print(path)        
        for ff in special[dir]:
            content = gen_model(j2_env, model, vars, maxlen, required, project, ff)
            touch_file(content, path, str.replace(ff, 'Client', model))

    #print("Dont forget to add a line in %.Web.Mvc/Startup/PageNames.cs" % args.project)
    #print("Create auto mapper %s.Application/%sApplicationModule.cs" % (args.project, args.project))
