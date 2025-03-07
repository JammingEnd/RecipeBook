# RecipeBook

omdat een MDF file niet met Github mee mag moet er nog iets gebeuren voordat je de applicatie kan gebruiken.

- Download Week-3
- open het .csproj file. in het mapje Database maak een Service-based Database aan met de naam ' ThuisOpdrachtenDb ". Dubbelklik vervolgens op die file
- Navigeer naar Tools -> nuget package manager -> nuget console
- 
- vul als eerste command in ' Add-Migration InitialCreate ' (als je een error krijgt moet je waarschijnlijk als eerste nog Enable-Migrations invullen)
- vervolgens tiep je ' Update-Database ' (als het goed is zou de database volledig zijn

- Als laatste druk je op Build -> Build (In de bin\debug\net8...\ vind je de EXE )

ik snap dat dit heel wat is, echter met wat meer tijd (een weekend) kan ik het voor elkaar krijgen om de database embedded in de exe te krijgen
