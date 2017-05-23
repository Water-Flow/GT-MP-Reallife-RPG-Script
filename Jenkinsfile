node {
	checkout scm
	
	stage('Sonar-Scanner') {			
		if (env.BRANCH_NAME != 'master') {
			if (env.BRANCH_NAME.startsWith('PR-')) {
				withSonarQubeEnv('TerraTex SonarQube') {
					sh "${tool 'SonarQubeScanner'}/bin/sonar-scanner -X -Dsonar.projectVersion=${BUILD_DISPLAY_NAME} -Dsonar.analysis.mode=preview -Dsonar.github.pullRequest=${CHANGE_ID} -Dsonar.github.oauth=${github_oauth} -Dsonar.github.repository=TerraTex-Community/GTMP-Real--Roleplay-Script"
				}
			} else {
				withSonarQubeEnv('TerraTex SonarQube') {
					sh "${tool 'SonarQubeScanner'}/bin/sonar-scanner -Dsonar.projectVersion=${BUILD_DISPLAY_NAME}"
				}
				timeout(time: 1, unit: 'HOURS') {
					def qg = waitForQualityGate()
					if (qg.status != 'OK') {
						error "Pipeline aborted due to quality gate failure: ${qg.status}"
					}
				}		
			}
		}
	}
	
	stage('Deploy') {
		if (env.BRANCH_NAME == 'master') {
			sh 'ssh root@terratex.eu "rmdir \\"D:/TerraTex/Spiele/GTMP/01_server/live/resources\\" /s /q"'
			sh 'ssh root@terratex.eu "mkdir \\"D:/TerraTex/Spiele/GTMP/01_server/live/resources/TerraTex-RL-RPG\\""'
			sh 'scp -r ./resources/TerraTex-RL-RPG root@terratex.eu:"D:/TerraTex/Spiele/GTMP/01_server/live/resources/TerraTex-RL-RPG"'
			
			sh 'ssh root@terratex.eu "copy \\"D:/TerraTex/Spiele/GTMP/02_configs/live/*.*\\" \\"D:/TerraTex/Spiele/GTMP/01_server/live/resources/TerraTex-RL-RPG/Configs\\""'
			sh 'ssh root@terratex.eu "xcopy \\"D:/TerraTex/Spiele/GTMP/03_shared_packages/*\\" \\"D:/TerraTex/Spiele/GTMP/01_server/live/resources\\" /E"'
			
		} else if (env.BRANCH_NAME == 'develop') {
			sh 'ssh root@terratex.eu "rmdir \\"D:/TerraTex/Spiele/GTMP/01_server/dev/resources\\" /s /q"'
			sh 'ssh root@terratex.eu "mkdir \\"D:/TerraTex/Spiele/GTMP/01_server/dev/resources/TerraTex-RL-RPG\\""'
			sh 'scp -r ./resources/TerraTex-RL-RPG root@terratex.eu:"D:/TerraTex/Spiele/GTMP/01_server/dev/resources/TerraTex-RL-RPG"'
			
			sh 'ssh root@terratex.eu "copy \\"D:/TerraTex/Spiele/GTMP/02_configs/dev/*.*\\" \\"D:/TerraTex/Spiele/GTMP/01_server/dev/resources/TerraTex-RL-RPG/Configs\\""'
			sh 'ssh root@terratex.eu "xcopy \\"D:/TerraTex/Spiele/GTMP/03_shared_packages/\\" \\"D:/TerraTex/Spiele/GTMP/01_server/dev/resources\\" /E"'
		}
	}
}
