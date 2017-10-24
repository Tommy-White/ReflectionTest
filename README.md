# ReflectionTest
(C#)How can I change the value of a variable during runtime, only by knowing its name?  


This repository including 2 projects :
## One  shows：
1. How to get Type information in runtime by using the System.Reflection dll.
2. How to access Executing Assembly and get more information
3. How to instantiate an object by using the System.Reflection dll.
4. Also cover the theme How can I change the value of a variable during runtime, only by knowing its name? 

## Anthor shows：
I would end this part of the tutorial about Reflection, with a cool and useful example.
  A common scenario when creating any sort of application, is the desire to save the users settings.
  When you get several settings, you will probably create a Settings class, which will handle loading and saving of the desired settings. Each time you need a new setting info in your Settings class, you will have to update the Load() and Save() methods, to include this new setting info. But hey, why not let the Settings class discover its own properties and then load and save them automatically?  With Reflection, it's quite easy, and if you have read the above project in the Reflection section of this repository, you should be able to understand the following example. 
 
**Please be aware that using Reflection WILL be slower than reading and writing known properties manually, so you should consider when to use it and when to opt for a faster approach!**
  


