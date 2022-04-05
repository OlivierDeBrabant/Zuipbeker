# Zuipbeker

## Eerste keer opstarten
- Geef een folderlocatie mee bij het opstarten
- In die folder wordt er een leeg Teams.txt bestand aangemaakt
- Sluit nadien het programma
- Vul in het Teams.txt bestand alle teams in (Ieder team op een nieuwe lijn)
- Sla het bestand op
- Nadien kan je de applicatie opnieuw opstarten en zullen de teams geladen worden als je dezelfde folder laadt

## Achterliggende Werking
### Log bestand
- Telkens er bij een teams een aanpassing wordt gedaan aan het aantal bier, zal er een nieuwe regels geschreven worden in het log.txt bestand

### Automatisch Opslaan van aantal bier per teams
- Per team wordt er een <<TEAMNAAM>>.txt bestand aangemaakt wanneer er voor het eerst een pint wordt geregistreerd
- In dat bestand zal het cummulatief aantal bier telkens opgeslaan worden op een nieuwe lijn
