pipeline {
  agent any
  stages {
    stage('Continuous Integration: Unit Test') {
      parallel {
        stage('CI_UnitTest_Backend') {
          post {
            success {
              dir(path: 'SomeWhereCinema.Backend') {
                archiveArtifacts 'SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'
                publishCoverage(adapters: [
                                                      istanbulCoberturaAdapter(
                                                            path: 'SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml', 
                                                            thresholds:[[
                                                                  failUnhealthy: true,
                                                                  thresholdTarget: 'Conditional',
                                                                  unhealthyThreshold: 80.0, // below 80%
                                                                  unstableThreshold: 50.0  // below 50%
                                                              ]]
                                                          )
                                                      ], checksName: '')
                    }

                  }

                }
                steps {
                  dir(path: 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest') {
                    echo 'remove histiory test results'
                    sh 'rm -rf TestResults'
                    sh 'dotnet add package coverlet.collector'
                    dotnetTest()
                    sh 'dotnet test --collect:\'Xplat Code Coverage\''
                  }

                }
              }

              stage('CI_UnitTest_FrontEnd') {
                steps {
                  dir(path: 'SomeWhereCinema.Frontend') {
                    sh 'npm cache clean --force'
                    sh 'npm cache verify'
                    sh 'npm install'
                    sh 'npm i @angular/cli'
                    sh 'npm list'
                    sh 'npm run ng v'
                  }

                }
              }

            }
          }

          stage('Continuous Integration: Build') {
            parallel {
              stage('CI_Build_BackEnd_DotNet') {
                steps {
                  dir(path: 'SomeWhereCinema.Backend') {
                    sh 'dotnet build'
                  }

                }
              }

              stage('CI_Build_BackEnd_DockerImage') {
                steps {
                  dir(path: 'SomeWhereCinema.Backend') {
                    sh 'docker build -t evensnachi/somewhere-cinema .'
                  }

                }
              }

              stage('CI_Build_FrontEnd') {
                steps {
                  dir(path: 'SomeWhereCinema.Frontend') {
                    sh 'npm cache clean --force'
                    sh 'npm cache verify'
                    sh 'npm install'
                    sh 'npm i @angular/cli'
                    sh 'npm run ng build --omit=dev'
                  }

                }
              }

            }
          }

          stage('CR_IntegrationTest') {
            agent any
            post {
              always {
                dir(path: 'SomeWhereCinema.Backend') {
                  sh(script: 'docker-compose down', returnStatus: true)
                }

              }

            }
            steps {
              dir(path: 'SomeWhereCinema.Backend') {
                sh 'docker compose up -d'
              }

              dir(path: 'SomeWhereCinema.FrontEnd') {
                sh 'npm i testcafe'
                sh 'testcafe --list-browsers'
                sh 'testcafe all E2ETest/test.ts'
              }

            }
          }

          stage('Continuous Delivery') {
            parallel {
              stage('CD_FrontEnd_To_Firebase') {
                agent any
                steps {
                  dir(path: 'SomeWhereCinema.Frontend') {
                    sh "firebase deploy --token ${firebase} "
                  }

                }
              }

              stage('CD_BackEnd_To_DockerHub') {
                agent any
                steps {
                  dir(path: 'SomeWhereCinema.Backend') {
                    withCredentials(bindings: [usernamePassword(
                                                          credentialsId: 'docker',
                                                          passwordVariable: 'PASSWORD', 
                                                          usernameVariable: 'USERNAME')]) {
                        sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                      }

                      sh 'docker push evensnachi/somewhere-cinema'
                    }

                  }
                }

              }
            }

            stage('CD_Performancetesting') {
              agent any
              steps {
                echo 'performance test'
              }
            }

          }
          environment {
            DOTNET_CLI_HOME = '/tmp/DOTNET_CLI_HOME'
            HOME = '/tmp/DOTNET_CLI_HOME'
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
          triggers {
            pollSCM('* * * * *')
          }
        }