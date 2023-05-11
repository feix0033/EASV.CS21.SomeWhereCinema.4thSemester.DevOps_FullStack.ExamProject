pipeline {
    agent any

    triggers {
        pollSCM('* * * * *')
    }

    environment {
        CI = 'true'
        DOTNET_ROOT = '/usr/bin/dotnet'
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
    
        // Continuous Integration
        // I will try to use Feature branching to develop this project.
        // The branch main as the Production branch will contain and Deploy, Release and Deliver all the Features. 
        // The branch FrontEnd will Integrate and Test all the FrontEnd Features.
        // The branch FrontEnd_Dev will as the Develop branch to do the feature develop.
        // The branch BackEnd will Integrate and Test all the BackEnd Features.  
        // The branch BackEnd_Dev will as the Develop branch to do the feature develop.
        
        // I will use Feature flag to hidden some feature during the Production process.
        
        
        stage('Merge FrontEnd') {
            when {
                branch('FrontEnd*')
            }
            agent any
            steps {
                // here just check the up stream doesn't have any change
                // afterward if there are conflict was not be fixed, unit test will fail
                // otherwise it will continuous 
                sh 'git fetch -a'
                sh 'git merge origin/FrontEnd'
            }
        }
        
        stage('Merge BackEnd') {
            when {
                branch('BackEnd*')
            }
            agent any
            steps {
                sh "git fetch -a"
                sh "git merge origin/BackEnd"
            }
        }
        
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
                dir('SomeWhereCinema.Frontend') {
                    sh 'npm cache clean --force'
                    sh 'npm cache verify'
                    sh 'npm install npm'
                    sh 'npm install'
                    sh 'npm i -g @angular/cli'
                    sh 'ng build'
                }
            }
        }

        stage('Build BackEnd') {
            when {
                branch('BackEnd*')
            }
            agent any
            steps {
                dir('SomeWhereCinema.Backend') {
                    sh 'dotnet build'
                }
            }
        }

        stage('Test BackEnd') {
            when {
                branch('BackEnd*')
            }
            agent any
            steps {
                // should be in the test project, not solution fold
                dir('SomeWhereCinema.Backend/SomeWhereCinema.UnitTest') {
                    echo 'remove histiory test results'
                    sh 'rm -rf TestResults'
                    sh 'dotnet add package coverlet.collector'
                    sh "dotnet test --collect:'Xplat Code Coverage'"
                }
            }
            post {
                success {
                    echo '====++++Test BackEnd executed successfully++++===='
                    archiveArtifacts 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'
//                     publishCoverage(
//                         adapters: [
//                             istanbulCoberturaAdapter(
//                                 path: "SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml",
//                                 thresholds:[[
//                                     failUnhealthy: true,
//                                     thresholdTarget: 'Conditional',
//                                     unhealthyThreshold: 80.0, // below 80%
//                                     unstableThreshold: 50.0  // below 50%
//                                 ]]
//                             )
//                         ],
//                         checksName: '',
//                         sourceFileResolver: sourceFile('STORE_LAST_BUILD')
//                     )
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
