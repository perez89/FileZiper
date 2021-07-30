# FileZiper

Console application that can create a zip file from a main folder (all folders and files inside that folder), excluding certain extensions, folders and file names.  

The program also allows the user to specify the destination of the zip: it can be stored locally, sent by email or in a fileshare.   
  
The user can invoke the application console with the following arguments:  
- the folder to zip (e.g. C:\\temp);  
- the final name of the zip file (e.g. final.zip);    
- a list of extensions to exclude  (e.g. .bmp, .jpg, .txt)

- a list of folders to exclude (e.g. git, diretório)
- a list of files to exclude (e.g. ficheiro1, filcheiro2)
- output type (e.g. localFile, filesShare, SMTP)
- alternative paramenters according to the output *see below

All files and sub files must be included in the output zip.  

Example:  
-source C:\Users\Perez\Pictures\WC -EExtension png txt -EFolder Sporting -EFile wc_face -output localfile -destination c:\xpto  

Source  
  -source {path to the root folder}

Exclude(optional)
  extensions use: -EExtension "extensions name"  
  folders use: -EFolder "folders name"  
  files use: -EFile "files name"  
  
To define the output use  
  -output {Output option} -destination {destination must match the output type}  
  
Output options:  
  localfile     
  smtp  
  fileshare  
    
    
  Destination rules:  
  For localfile the destination must match a existing folder path  
  For smtp the destination must match a email  
  For fileshare the destination must match a existing folder path  
  
