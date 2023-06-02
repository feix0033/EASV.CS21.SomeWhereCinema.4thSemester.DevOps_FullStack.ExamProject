---
title: Some Where Cinema -- exam project
auther: Fei Gu
GitHub-link: https://github.com/feix0033/EASV.CS21.SomeWhereCinema.4thSemester.DevOps_FullStack.ExamProject.git
Web-App-link: https://somewherecinema-76ded.web.app/
Docker-image: evensnachi/somewhere-cinema
DockerHub-link: https://hub.docker.com/repository/docker/evensnachi/somewhere-cinema/general
---



# Introduction

This is the EASV 4th semester DevOps Exam Project which combined with Fullstack Exam Project.

## The "Some Where Cinema Project"

This project prepose i create a Web application for Customer can check and order movie ticket though webpage. And The cinema manager can manage the movie projection plan though the application. 

### Project Architecture

#### Frontend

The frontend contain an angular Web Application which have user management component, movie info component, order system component. 

The frontend web app will offer all the user interface to let the user and manager can create, read, update, delete relevant info such as order, movie etc with appropriate authenticate. 

#### Backend 

The backend contain a dotNet 7 framework which based on onion architecture included a mysql database and web api.

The backend will offer the service for manipulate data with database. So the data modify will happened on service but not user's browser. 

#### Firebase 

Because following the Fullstack requirement this project will use google firebase as the middleware which have auth service, cloud storage service, cloud non-sql database. 

Firebase will offer the user authentication and do the requirement to backend to get right data. 

# How to install 

## Pre-request

- Docker engine or Docker Desktop
- Browser

## Install backend server.
- Run comment `docker run -p 7000:7000 --name somewherecinema evensnachi/somewhere-cinema`

## Start 
- Open this link : [Some Where Cinema](https://somewherecinema-76ded.web.app/)


# Links 

GitHub-link: https://github.com/feix0033/EASV.CS21.SomeWhereCinema.4thSemester.DevOps_FullStack.ExamProject.git  
Web-App-link: https://somewherecinema-76ded.web.app/  
Docker-image: evensnachi/somewhere-cinema  
DockerHub-link: https://hub.docker.com/repository/docker/evensnachi/somewhere-cinema/general  



# Use Case
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