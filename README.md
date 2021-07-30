# FileZiper

Aplicação de linha de comandos que consegue criar um zip de uma pasta e
respetivas sub-pastas, excluindo determinadas extensões, pastas ou nomes de ficheiros.  

O programa também permite que o ficheiro output possa ser gerado para uma pasta local, copiado
para uma fileshare ou enviado como anexo por Email (SMTP).  
  
  
Como utilizador posso invocar a aplicação via linha de comandos passando como argumentos:
- a pasta a zipar (e.g. C:\\temp)
- o nome final do ficheiro zip (e.g. final.zip)
- uma lista de extensões a excluir (e.g. .bmp, .jpg, .txt)
- uma lista de diretórios a excluir (e.g. git, diretório)
- uma lista de ficheiros a excluir (e.g. ficheiro1, filcheiro2)
- tipo de output (e.g. localFile, filesShare, SMTP)
- parâmetros opcionais de acordo com o tipo de output (e.g. path do fileshare)

Todos os ficheiros e pastas devem ser incluídos no ficheiro de output num ficheiro ZIP.

-source C:\Users\Perez\Pictures\WC -EExtension png txt -EFolder Sporting -EFile wc_face -output localfile -destination c:\xpto

Exclude   
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
  
