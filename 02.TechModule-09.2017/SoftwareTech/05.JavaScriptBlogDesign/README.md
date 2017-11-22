
## JavaScript ExpressJS exercise - Calculator

###This project contains a calculator made with:

- [node.js](https://nodejs.org/en/ "nodejs.org")
- [mongodb](https://www.mongodb.com/download-center#community "mongodb.com")
- express.js
- mongoose.js
- handlebars.js
- passport.js	

full detailed list can be seen in package.json

###Functionality:

- Register new user
- Login user
- Logout user
- Make new article
- See 6 articles

## How to run the project
**To run the project you have to have *node.js* and *MongoDB* installed.**

1. Start the command window under Windows from the project's root directory
	- navigate to the root directory and hit `shift + F10` or `shift + right click`  and select **"Open command window here"** option from the drop-down menu.
	- OR hit `win + R`, type **cmd.exe** and hit enter. Then navigate to the root folder of this project (cd "full path to directory")

2. Run command: **npm install**
	- This will install all necessary modules from package.json (it may take some time)

3. Create folder **"db"** in the directory

4. Start MongoDB server at the new directory: **mongod --dbpath ./db**

5. Open **new command window** (step 1) and run command: **node bin/www**
	- This will run node server listening at port 3000

Now the app is running at [localhost:3000](http://localhost:3000 "localhost:3000")

if you have difficulties running the project you can look [here](https://github.com/Steffkn/SoftUni/blob/master/02.TechModule-09.2017/SoftwareTech/05.JavaScriptBlogDesign/tasks/08.%20Software-Technologies-JS-Blog-Getting-Started-Lab.docx "Software-Technologies-JS-Blog-Getting-Started.docx") for more information.