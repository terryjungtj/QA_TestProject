# Quality/Automation Test Program

This program is an automated test solution for personal training purposes. The "Gatling Computer Database" and "Java Scrip Alert" open-source web applications are used as a testing ground to perform various tests. The implemented tests covers the CRUD operations, edge cases, as well as handling java script alert windows.

## 1. Testing Ground Overview
### 1.2. Gatling Computer Database
The Gatling computer database (http://computer-database.gatling.io/computers)  is an open-source testing framework. The program can be used as an example to cover the CRUD operations, as well as edge cases when developing an automated testing solution. The preconditions, steps and expected results for each operation will be discussed in detail below.

Note: 
The program to date only allows the user to read only. Thus, it is not possible to make changes (create, update, delete) to the pre-existing data. The only way to confirm successful changes are through the built-in notifications. 

### 1.3. Java Script Alerts
 The JavaScript Alerts program (https://the-internet.herokuapp.com/javascript_alerts) is another open-source testing program, designed to assist the development of handling JavaScript alert windows automatically. For this purpose, the program will handle 3 different types of alert windows.



## 2. Getting Started

### 2.1. Prequisites
* Check the chrome version in the settings 
  ![image text](https://i.imgur.com/77iVqF7.png)
* Go to the following URL (https://chromedriver.chromium.org/downloads) and download the chrome driver version that matches the browser version (v92).
* Place the chrome driver in the C:\Driver directory as shown below.
![image text](https://i.imgur.com/Yu9QqVT.png)

### 2.2. Nuget packages
* Nunit (by Charlie Poole, Rob Prouse)
* Nunit3TestAdapter (by Charlie Poole, Terje Sandstorm)
* Selenium.Support (by Selenium Committers)
* Selenium.WebDriver (by Selenium Committers)
* Selenium.WebDriver.ChromeDriver (by jsakamoto)
* SeleniumExtras.WaitHelpers (by SeleniumExtras.WaitHelpers)

### 2.3. Setup

* Clone repository to local storage (directory shouldn't matter)
* Open the "QA_TestProject.sln"

### 2.4. Executing program

* Open the “QA_TestProject.sln” with Visual Studio (2019 or newer)
* Using the “Test Explorer”, either right click to run the specific test case, or click the “green” triangle to run all the test cases 
![image text](https://i.imgur.com/OCGSOfy.png)

## 3. Help
"TearDown" is enabled by default, meaning that the browser will launch and close automatically for each test. As a result, the process may fly past very quickly depending on the internet speed and pc specs. In order to get a better view of the test results, it might be helpful to comment out lines 229-230 and 366-367.
```
[TearDown]
public void TearDown() => driver.Quit();
```

## 4. Authors

### 4.1. Name
Terry Jung
terryjungtj@hotmail.com 

### 4.2 Total Time Taken
Roughly 3 hours
