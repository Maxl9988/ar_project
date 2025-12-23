# ar_project

Mit einer neuen Quest 3 muss erst das folgende setup gemacht werden:
https://developers.meta.com/horizon/documentation/unity/unity-mr-utility-kit-gs


Projektdokumentation:

1. Projektübersicht und Zielsetzung

Im Rahmen des Moduls Mixed Reality wurde eine Augmented-Reality-Anwendung entwickelt, die eine interaktive Unterweisung an einer realen Tischbohrmaschine ermöglicht. Ziel des Projekts war es, eine praxisnahe Möglichkeit zu schaffen, die Funktionsweise, Bedienelemente und grundlegenden Einstellungen der Maschine direkt an der physischen Bohrmaschine zu vermitteln. Der Nutzer soll die Maschine durch aktive Interaktion kennenlernen und sich so mit der Maschine vertraut machen. Die Anwendung ist als Ergänzung oder Alternative zu klassischen Einweisungen gedacht.


2. Technischer Rahmen

Die Umsetzung des Projekts erfolgte mit der Game Engine Unity. Als Hardware wurde eine Meta Quest 3 verwendet. Für die Entwicklung und die AR-Funktionalitäten kam das Meta All-In-One SDK zum Einsatz. Die Anwendung nutzt den Passthrough-Modus der Meta Quest 3, wodurch die reale Umgebung sichtbar bleibt und virtuelle Inhalte direkt in diese eingeblendet werden können.

Zur räumlichen Erkennung und Initialisierung der Bohrmaschine wird die QR-Code-Trackable-Funktion des Meta SDK verwendet. Dabei werden String QR-Codes ("Red", "Blue", ...)erzeugt, um verschiedene Ereignisse zu handeln. Die QR-Codes werden auf dem Tisch angebracht, sodass die physische Bohrmaschine stets in einer festen und reproduzierbaren Position im Raum ausgerichtet ist.


3. Konzept und Umsetzung

Nach dem Scannen des QR-Codes wird ein virtuelles Modell der Bohrmaschine in der realen Umgebung platziert. Dieses Modell besteht aus mehreren einzelnen 3D-Objekten, die jeweils reale Komponenten der Bohrmaschine abbilden. Dazu zählen im aktuellen stand 7 Knöpfe der Bohrmaschine.

Die einzelnen 3D-Objekte werden mit einer leicht transparenten Materialdarstellung versehen und möglichst deckungsgleich über die entsprechenden physischen Bauteile gelegt. Um eine konsistente Platzierung zu gewährleisten, werden den 3D-Objekten feste Transformationen relativ zum erkannten QR-Code zugewiesen. Jedes Objekt besitzt einen eigenen Collider, der bei einer Interaktion eine definierte Aktion auslöst, beispielsweise eine visuelle Hervorhebung, eine Farbänderung oder das Öffnen eines Informationsfensters mit erklärenden Inhalten.


4. Interaktionskonzept

Die Interaktion mit den virtuellen Objekten erfolgt über das Handtracking der Meta Quest 3. In einem ersten Ansatz wurde ein Collider auf die gesamte Hand gelegt. Dieser Ansatz erwies sich jedoch als zu ungenau, insbesondere bei der Interaktion mit den kleinen Bedienelementen der Bohrmaschine.

Daraufhin wurde eine virtuelle Hand in die Anwendung integriert, um dem Nutzer eine visuelle Rückmeldung über die tatsächliche Interaktionsposition zu geben. Der Collider wurde anschließend ausschließlich dem Zeigefinger der virtuellen Hand zugewiesen. Auch dieser Ansatz zeigte jedoch Einschränkungen bei sehr kleinen Knöpfen. Zusätzlich traten Probleme auf, wenn virtuelle Objekte bei der Initialisierung minimal hinter den physischen Bedienelementen lagen oder wenn die virtuelle Hand kleiner skaliert war als die reale Hand des Nutzers.

Um diese Probleme zu beheben, wurde der Collider weiter verkleinert, visuell als kleine Kugel dargestellt und um etwa fünf Zentimeter von der Zeigefingerspitze der virtuellen Hand nach vorne versetzt. Durch diese Anpassungen wurde eine deutlich präzisere und zuverlässigere Interaktion ermöglicht, auch bei sehr kleinen Bedienelementen und ohne unbeabsichtigte Mehrfachauslösungen.


5. Erfahrungen im Entwicklungsprozess

Der Entwicklungsprozess erwies sich insgesamt als sehr zeitintensiv. Bereits das initiale Setup zur Aktivierung von Passthrough und QR-Code-Erkennung ist aufwendig und erfordert eine umfangreiche Konfiguration. Zusätzlich muss die Anwendung bei jeder Änderung neu gebaut und über eine Kabelverbindung direkt auf die Meta Quest 3 übertragen werden, was den Entwicklungszyklus deutlich verlangsamt.

Zur Beschleunigung dieses Zyklus wurde der Einsatz eines AR-Simulators getestet. Dieser Ansatz wurde jedoch nicht weiterverfolgt, da die QR-Code-Erkennung im Simulator nicht unterstützt wird. Außerdem hätte die Integration der physischen Bohrmaschine in eine simulierte Umgebung zusätzlichen Aufwand bedeutet, der für dieses Projekt nicht verhältnismäßig gewesen wäre.


6. Probleme, Grenzen und offene Punkte

Die Initialisierung der 3D-Objekte über den QR-Code funktioniert hinsichtlich Positionierung und Wiederholgenauigkeit grundsätzlich gut. Die Abweichungen liegen im Bereich weniger Millimeter. Problematisch ist jedoch die unregelmäßige Erkennung des QR-Codes, die nur in zeitlich variierenden Abständen im niedrigen Sekundenbereich erfolgt. Bei einer kontinuierlichen Aktualisierung der Objektpositionen führt dies zu kleinen, aber wahrnehmbaren Positionssprüngen der virtuellen Elemente, was die Nutzererfahrung negativ beeinflusst.

Aus diesem Grund wurde entschieden, den QR-Code ausschließlich einmalig zur Initialisierung zu verwenden. Eine nachträgliche manuelle Ausrichtung der Objekte durch den Nutzer wurde zwar in Betracht gezogen, jedoch verworfen, da die Positionssprünge weiterhin bestehen würden.

Ein weiteres bislang ungelöstes Problem sind leichte Positionssprünge der auf die Bedienelemente projizierten 3D-Objekte, insbesondere bei sehr naher Betrachtung in der AR-Brille. Auffällig ist, dass frei im Raum platzierte 3D-Objekte dieses Verhalten nicht zeigen, selbst bei geringer Distanz und intensiver Interaktion. Es wird vermutet, dass dieses Verhalten mit den Materialeigenschaften, Farben oder der komplexen Geometrie der Bohrmaschine sowie mit der Nähe-Interaktion zusammenhängt. Eine konkrete Lösung konnte hierfür bisher nicht gefunden werden.


7. Fazit und Ausblick

Das Projekt zeigt, dass eine AR-gestützte Unterweisung an einer realen Maschine mit aktueller Consumer-Hardware grundsätzlich umsetzbar ist und ein hohes Potenzial für praxisnahe Lernszenarien bietet. Gleichzeitig wurden im Verlauf des Projekts mehrere technische Einschränkungen identifiziert, insbesondere in den Bereichen Tracking-Stabilität, Entwicklungsworkflow und präzise Feininteraktion.
