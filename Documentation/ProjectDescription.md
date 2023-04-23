# Project Description

*by Fei Gu*

*EASV.4thSemester.DevOps&Fullstack*

## About Project

This is the DevOps Exam Project combind with Fullstack Exam Project.

*Note: so far this description only writed for DevOps process.*

Project perpose is create a Web Application for Customer can ordering the cinema tickets from cinema's web page. And then the cinema manager can manage the movie projection info and ordring info. 

### Frontend

The Web Application will be front and to implament the user register, the movie info reseach, projection info reseach, ordring ticket, ordring info reseach and so on. 

The firebase cloud service will deploy the webside hosting which with the webpage. Also contain the user infomation. 

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