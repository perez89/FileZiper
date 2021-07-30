# FileZiper

Console application that can create a zip from a main folder (all folders and files inside that folder), excluding certain extensions, folder and file names.  

The program also allow the user to specific the destination of the zip, it can be store local, sent by email or in a fileshare.   
  
Como utilizador posso invocar a aplicação via linha de comandos passando como argumentos:  
- a pasta a zipar (e.g. C:\\temp)
- o nome final do ficheiro zip (e.g. final.zip)
- uma lista de extensões a excluir (e.g. .bmp, .jpg, .txt)
- uma lista de diretórios a excluir (e.g. git, diretório)
- uma lista de ficheiros a excluir (e.g. ficheiro1, filcheiro2)
- tipo de output (e.g. localFile, filesShare, SMTP)
- parâmetros opcionais de acordo com o tipo de output (e.g. path do fileshare)

All files and sub files must be include in the output zip.  

Example:  
-source C:\Users\Perez\Pictures\WC -EExtension png txt -EFolder Sporting -EFile wc_face -output localfile -destination c:\xpto


Source  
  -source {path to the root folder}

Exclude(optional)
  extensions use: -EExtensions "extensions name"  
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
  
