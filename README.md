# jsonpatch

This is a CLI wrapper for https://github.com/wbish/jsondiffpatch.net

Command line interface to perform a diff of two JSON files. I couldnt find a stands alone CLI to perform a diff that didnt require Node or some other kind of runtime so I wrote this. Intention is to call this from PowerShell,

Execute as follows;

jsonpatch.exe -action diff -left json1.txt -right json2.txt

This will produce a diff into a file called output.json

You can also create a patch JSON by running

jsonpatch.exe -action patch -left json1.txt -right json2.txt

See https://github.com/wbish/jsondiffpatch.net for example files.
