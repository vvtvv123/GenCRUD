#!/usr/bin/python3
# 
# Using the file system load
#
# We now assume we have a file in the same dir as this one called
# test_template.html
#

import argparse
import os
from jinja2 import Environment, FileSystemLoader

# Capture our current directory
THIS_DIR = os.path.dirname(os.path.abspath(__file__))

def print_html_doc(j2_env):        
    print(j2_env.get_template('Index.cshtml').render(
        title='Hellow Gist from GutHub'
    ))    

if __name__ == '__main__':

    parser = argparse.ArgumentParser(description='Generate asp.net code for a model')
    
    parser.add_argument("-f", help='model description file', dest="model", required=True)
    parser.add_argument("-p", help='project name', dest="project", required=True)
    parser.add_argument("-d", help='destination directory', dest="path", required=True)
    args = parser.parse_args()
    print(args.path)

    # Create the jinja2 environment.
    j2_env = Environment(loader=FileSystemLoader(THIS_DIR+"/template"),
                         trim_blocks=True)

    print_html_doc(j2_env)

