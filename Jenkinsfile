pipeline {
    agent any

    triggers{
        pollSCM("* * * * *")
    }

    environment {
        CI = 'true'
        DOTNET_ROOT = '/usr/bin/dotnet'
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
        stage('Build FrontEnd') {
            when {
                branch('FrontEnd*')
            }
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            steps {
                echo '====++++executing Build FrontEnd++++===='
                dir('SomeWhereCinema.Frontend') {
                    sh 'npm cache clean --force'
                    sh 'npm cache verify'
                    sh 'npm install npm'
                    sh 'npm install'
                    sh 'npm i -g @angular/cli'
                    sh 'ng build'
                }
            }
            post {
                always {
                    echo '====++++Build FrontEnd executed finish++++===='
                }
                success {
                    echo '====++++Build FrontEnd executed successfully++++===='
                }
                failure {
                    echo '====++++Build FrontEnd execution failed++++===='
                }
            }
        }

        stage('Build BackEnd') {
            when {
                branch('BackEnd*')
            }
            agent any
            steps {
                echo '====++++executing Build BackEnd++++===='
                sh 'pwd'
                dir('SomeWhereCinema.Backend') {
                    sh 'dotnet build'
                }
            }
            post {
                always {
                    echo '====++++alwayBuild BackEnd executed finish++++===='
                }
                success {
                    echo '====++++Build BackEnd executed successfully++++===='
                }
                failure {
                    echo '====++++Build BackEnd execution failed++++===='
                }
            }
        }

        stage('Test BackEnd') {
            when {
                branch('BackEnd*')
            }
            agent any
            steps {
                echo '====++++executing Test BackEnd++++===='
                // should be in the test project, not solution fold
                dir('SomeWhereCinema.Backend/Core.Model.Test') {
                    
                    echo 'remove histiory test results'
                    sh 'rm -rf TestResults'
                    sh 'dotnet add package coverlet.collector'
                    sh "dotnet test --collect:'Xplat Code Coverage'"
                }
            }
            post {
                always {
                    echo '====++++always++++===='
                }
                success {
                    echo '====++++Test BackEnd executed successfully++++===='
                    archiveArtifacts 'SomeWhereCinema.Backend/Core.Model.Test/TestResults/*/coverage.cobertura.xml'

                    // publishCoverage(
                    //     adapters: [
                    //         istanbulCoberturaAdapter(
                    //             path: "SomeWhereCinema.Backend/Core.Model.Test/TestResults/*/coverage.cobertura.xml",
                    //             thresholds:[[
                    //                 failUnhealthy: true,
                    //                 thresholdTarget: 'Conditional',
                    //                 unhealthyThreshold: 80.0, // below 80%
                    //                 unstableThreshold: 50.0  // below 50%
                    //             ]]
                    //         )
                    //     ],
                    //     checksName: '',
                    //     sourceFileResolver: sourceFile('STORE_LAST_BUILD')
                    // )
                }
                failure {
                    echo '====++++Test BackEnd execution failed++++===='
                }
            }
        }

        stage('Deploy') {
            agent any

            steps {
                echo '====++++executing Deploy++++===='
            }
            post {
                always {
                    echo '====++++Deploy finish++++===='
                }
                success {
                    echo '====++++Deploy executed successfully++++===='
                }
                failure {
                    echo '====++++Deploy execution failed++++===='
                }
            }
        }

        stage('Deliver') {
            agent any

            steps {
                echo '====++++executing Deliver++++===='
            }
            post {
                always {
                    echo '====++++Devliver finishi++++===='
                }
                success {
                    echo '====++++Deliver executed successfully++++===='
                }
                failure {
                    echo '====++++Deliver execution failed++++===='
                }
            }
        }
    }

    post {
        always {
            echo '====++++All stages finish++++===='
            deleteDir()
        }
        success {
            echo '====++++successfully++++===='
        }
        failure {
            echo '====++++failed++++===='
        }
    }
}
