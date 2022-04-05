> Indien je de applicatie enkel wilt testen staat de ZuipbekerApp.exe file in de map bin/Debug

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

## Installer folder
- Deze map bevat een installer (Weet niet zeker of dit werkt op andere pc's of demijne (Olivier))

## Files folder
- Deze map bevat de teams. Je kan ook kiezen om zelf een nieuwe locatie te gebruiken om je eigen teams in op te slaan.

## TODO
- Dynamische fontsize (Top 3 al gedaan, overige teams nog niet)
- Errorhandling
- Styling op Admin pagina
- Index geven aan teams buiten top 3
