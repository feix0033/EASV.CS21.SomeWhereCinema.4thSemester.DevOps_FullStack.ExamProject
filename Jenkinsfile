pipeline {
    agent any

    environment {
        CI = 'true' 
        DOTNET_ROOT="/usr/bin/dotnet"
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
        stage('Build') {
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            
            steps {
                sh 'npm --version'
                sh 'node --version'
                
            }
        }
        stage ('build dotnet'){
            agent any
            steps {
                dir( 'SomeWhereCinema.Backend'){
                sh 'dotnet --version'
                }
            }
        }

        stage('Test') { 
            steps {
                echo 'this is test process'
            }
        }

        stage ('Deploy') {
            steps {
                echo 'merge branch'
                sh ('git checkout BackEnd')
                sh ('git branch')
                sh ('git pull')
                sh ('git merge BackEnd_Dev')
                sh ('''
                    git remote remove origin
                    git remote add origin git@github.com:feix0033/EASV.CS21.SomeWhereCinema.4thSemester.DevOps_FullStack.ExamProject.git
                ''')
                sh ('git push origin BackEnd')
            }
        }
    }

    post {
        always {
            deleteDir()
        }
    }

}