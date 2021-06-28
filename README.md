# LanguageGuesserApp

A Windows Forms application that guesses the language a user is typing in.

To try out the application, download build.zip, extract all and open the LanguageApp.exe. 
Use Visual Studio to look at the code.

Basically, I used ML.NET to train an AI that can guess the language. 
One part of the program takes in text from the internet and puts seperates it into sentences. The sentences are labeled with a language and saved into a TSV file.
To generate a file, go to Program.cs in LanguageApp. 
Add your online resources to the resources array (more info is commented in the code) and call the function addDataToDocument() in Main().

LanguageAppML.Model is the AI I trained using data I generated. languages.TSV is the file I used to train it.

The Windows form passes the input text into the model and the model sends back the language so the windows form can display it.

Languages it recognizes: 
English, French, Spanish, German, Polish, Finnish, Czech, Latin,  Afrikaans, Italian, Portugese, Catalan, Frisian, Irish, Norwegian, Dutch, Romanian, Swedish, Danish
