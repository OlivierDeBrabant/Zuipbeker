> !! Wanneer je de files folder cloned en niet verwijdert zal de applicatie de teams uit de files folder gebruiken !!

# Zuipbeker
Deze applicatie dient om het systeem van een zuipbeker op een evenement te digitaliseren. De applicatie opent een Admin pagina die dient om voor ieder team bier toe te voegen en te verwijderen en opent een Scorebord pagina die dient om de tussenstand van alle teams te tonen.

## Eerste keer opstarten
1. Geef een folderlocatie mee bij het opstarten
2. In die folder wordt er een leeg Teams.txt bestand aangemaakt
3. Sluit nadien het programma
4. Vul in het Teams.txt bestand alle teams in (Ieder team op een nieuwe lijn)
5. Sla het bestand op
6. Nadien kan je de applicatie opnieuw opstarten en zullen de teams geladen worden als je dezelfde folder laadt

## Achterliggende Werking
### Log bestand
- Telkens er bij een teams een aanpassing wordt gedaan aan het aantal bier, zal er een nieuwe regels geschreven worden in het log.txt bestand

### Automatisch Opslaan van aantal bier per teams
- Per team wordt er een TEAMNAAM.txt bestand aangemaakt wanneer er voor het eerst een pint wordt geregistreerd
- In dat bestand zal het cummulatief aantal bier telkens opgeslaan worden op een nieuwe lijn

## TODO
- Dynamische fontsize (vooral op Scorebord pagina)
- Errorhandling
- Styling op Admin pagina
