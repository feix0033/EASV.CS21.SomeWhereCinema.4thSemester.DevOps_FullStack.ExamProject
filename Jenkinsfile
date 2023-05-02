pipeline {
    agent any

    triggers {
        pollSCM ( "H * * * *")
    }

    environment {
        CI = 'true' 
        DOTNET_ROOT="/usr/bin/dotnet"
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
        stage("Unit Test BackEnd"){
            steps{
                echo "====++++executing Unit Test BackEn++++===="
            }
            post{
                always{
                    echo "====++++  Unit Test BackEnd Finish ++++===="
                }
                success{
                    echo "====++++Unit Test Back executed successfully++++===="
                }
                failure{
                    echo "====++++Unit Test Back execution failed++++===="
                }
        
            }
        }

        stage("Build FrontEnd"){
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            steps{
                echo "====++++executing Build FrontEnd++++===="
                sh 'pwd'
                // sh 'cd /var/lib/jenkins/workspace/SomeWhereCinema_FrontEnd_Dev@2/'
                sh 'pwd'
                dir ('SomeWhereCinema.Frontend') {
                    sh 'pwd'
                    sh 'ls'
                    sh 'npm install'
                    // sh 'npm i @angular/cli'
                    sh 'ng build'
                }
            }
            post{
                always{
                    echo "====++++Build FrontEnd executed finish++++===="
                }
                success{
                    echo "====++++Build FrontEnd executed successfully++++===="
                }
                failure{
                    echo "====++++Build FrontEnd execution failed++++===="
                }
        
            }
        }

        stage("Build BackEnd"){
            agent any
            steps{
                echo "====++++executing Build BackEnd++++===="
                sh 'dotnet build'
            }
            post{
                always{
                    echo "====++++alwayBuild BackEnd executed finish++++===="
                }
                success{
                    echo "====++++Build BackEnd executed successfully++++===="
                }
                failure{
                    echo "====++++Build BackEnd execution failed++++===="
                }
        
            }
        }

        stage("Test"){
            steps{
                echo "====++++executing Test++++===="
            }
            post{
                always{
                    echo "====++++Test finish++++===="
                }
                success{
                    echo "====++++Test executed successfully++++===="
                }
                failure{
                    echo "====++++Test execution failed++++===="
                }
        
            }
        }

        stage("Deploy"){
            steps{
                echo "====++++executing Deploy++++===="
            }
            post{
                always{
                    echo "====++++Deploy finish++++===="
                }
                success{
                    echo "====++++Deploy executed successfully++++===="
                }
                failure{
                    echo "====++++Deploy execution failed++++===="
                }
        
            }
        }

        stage("Deliver"){
            steps{
                echo "====++++executing Deliver++++===="
            }
            post{
                always{
                    echo "====++++Devliver finishi++++===="
                }
                success{
                    echo "====++++Deliver executed successfully++++===="
                }
                failure{
                    echo "====++++Deliver execution failed++++===="
                }
        
            }
        }
    }

    post {
        always{
            echo "====++++All stages finish++++===="
            deleteDir()
        }
        success{
            echo "====++++successfully++++===="
        }
        failure{
            echo "====++++failed++++===="
        }
    }
}