# TheTurtleChallange

## How to run 

To run the code first publish it before for your OS (e.g. for win use the command "dotnet publish -c Debug -r win10-x64").  
Then you can run it as normal console app "TheTurtleChallange.exe -gameSettings '{Your game setting file}' -moves {Your moves file}"

## Input files

Accepts two input files 

### Game Settings 

Is a JSON file like 

```json
{
	"InitPosition": {
		"Tile": {
			"X": 0,
			"Y": 1
		},
		"Direction": "North"
	},
	"ExitPosition": {
		"X": 4,
		"Y": 2
	},
	"MinesPosition": [
		{
			"X": 1,
			"Y": 1
		},
		{
			"X": 3,
			"Y": 1
		},
		{
			"X": 3,
			"Y": 3
		}
	],
	"GridSize": {
		"X": 5,
		"Y": 4
	}
}
```

### Moves 

A simple plain text file contains "m,r,m,m,r,m"


Cheers :beers: