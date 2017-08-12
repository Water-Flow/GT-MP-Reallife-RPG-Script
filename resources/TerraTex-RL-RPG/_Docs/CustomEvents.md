# List of custom Client Events
 <table>
	<tr>
		<th>EventName</th>
		<th>Arguments</th>
		<th>Description</th>
	</tr>
	<tr>
		<td>OnClick</td>
		<td>
			<ul>
				<li>{LocalHandle} localHandle - Local Entity Handle</li>
			</ul>
		</td>
		<td>Gets triggered when player clicks on something via clicksys</td>
	</tr>
	<tr>
		<td></td>
		<td>
			<ul>
				<li>{datatype} ArgName - Description</li>
			</ul>
		</td>
		<td></td>
	</tr>
 </table>

 # List of Serverside custom Events
 - TTRPG.OnTerraTexStartUpFinishedEvent - Gets triggered after full start of TerraTex
 - ConsoleReader.OnConsoleMessageEvent - Gets triggered when a console command was entered
 - GmxTimer.OnTerraTexStopEvent - Gets triggered after all players got kicked on shutdown