# Project Description

*by Fei Gu*

*EASV.4thSemester.DevOps&Fullstack*

## About Project

This is the DevOps Exam Project combind with Fullstack Exam Project.

Project perpose is create a Web Application for Customer can ordering the cinema tickets from cinema's web page. And then the cinema manager can manage the movie projection info and movie info. 

### Frontend

The Web Application will be front and to implament the user register, the movie info reseach, projection info reseach, ordring ticket, ordring info reseach and so on. 

The firebase cloud service will deploy the webside hosting which with the webpage. Also contain the user infomation. 

#### US1 --User
- The user can registor a count by click the router link rigistor and input info. 
- By click the rigistor button to push user info to firebase authentication and rigistor. 
- By click user info router link to go to user info page. 
- The firebase auth will check the userID and User token will correct or not.
- The user can delete user acount by click 'delete my account' button.

#### US2 --Movie
- The user can click Movie router link to visit movie page to see the avaliable movie. 
- The movie will show up post and name, price. 
- by click each movie, the user can choose the movie's projection time. 
- by click projection time, can router to order page witch include movie info and projection info 
- by click order ticket button can order the movie. (router to payment page)

#### US3 --order
- The user can click order router link to check own order history.
- the firebase auth will check the userid and usertoken to sure correct.
- the order info will seach and show current user's order

### Backend

The Cinema serve can be login by manager account. Can be offer Movie information manage, therater information manage, projection infomation manage, ticket manage and so on. 

## Develop 

### Frontend

The web application will base on Angular framework using Angular routering and service to require data from both firestore and backend. 

It will use Jenkins as CI/CD tools. to do the webapp implament unit test(testcafe), build (ng build), continuouing test (jenkins pipeline, code caverage), deploy(firebase deploy, E2Etesting by testcafe, performance testing by k6, etc), release(on the firebase hosting webside).

The firebase will have the user authentication, firestore, storage, firebase hosting and so on. 

### Backend

The server will be develop by .Net 7. Using Clean Architecture. The unit test will cover all the layer's test. Git as VCS and SCM tools. Github will be the remote serve. Jenkins as CI/CD tools will do all the process for backend unittest, build, test, delivery, deploy, operations. It will also as branch stratage tool to auto test and merge the feature branch by feaure flags.

## suffix

I understand I will not fully complete this project during the all exam process by my self. But i will firstly make the basic structure and feature to let this program working and try to reach all the study porpose during this semester. 