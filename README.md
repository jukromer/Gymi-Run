<div align="center">

<img src="Assets/Pictures/Herr%20Werber.png" alt="Herr Werber – FCA Ultra" width="180" style="image-rendering: pixelated;" />

# Gymi-Run

**Ein 2D Jump'n'Run, in dem die Lehrer zurückschlagen.**

![engine](https://img.shields.io/badge/engine-Unity_2021.3-222c37?style=flat-square&logo=unity)
![language](https://img.shields.io/badge/language-C%23-239120?style=flat-square&logo=csharp)
![type](https://img.shields.io/badge/type-2D_Platformer-orange?style=flat-square)
![status](https://img.shields.io/badge/status-playable-brightgreen?style=flat-square)
![project](https://img.shields.io/badge/made_for-school-blueviolet?style=flat-square)

</div>

---

Gymi-Run ist ein Schulprojekt — ein kleines Unity-Game voller Insider, in dem du als Schüler durchs Klassenzimmer rennst, Münzen sammelst, gefährlichen Abfragen ausweichst und es am Ende mit einem ganz besonderen Endgegner aufnimmst.

## Worum geht's?

Du wählst deinen Charakter, lernst im Tutorial die Steuerung, kämpfst dich durch zwei Level und versuchst, den Highscore zu knacken. Klingt simpel — bis dir die erste Mathe-Abfrage entgegenfliegt.

## Features

- **5 spielbare Charaktere** — wähle aus Pascal, Leon, Julian, Fabian oder dem klassischen Strichmännchen
- **Lehrer als Endgegner** — Boss-Fight mit eigener Health-Bar, Angriffsmustern und Projektilen
- **Münzen & Power-Ups** — sammle 10 Coins, um Schild oder Heal freizuschalten
- **Tutorial-Modus** — eine geführte Sequenz, die dir die Steuerung beibringt
- **Parallax-Backgrounds** — mehrschichtige Szenerie mit Bäumen, Häusern und Himmel
- **Highscore-System** — persistent gespeichert über `PlayerPrefs`
- **Camera Shake & Damage Vignette** — weil Treffer wehtun sollen
- **Eigener Soundtrack** — inklusive *Sneaky Snitch* und *Monkeys Spinning Monkeys*

## Levels

| Szene | Inhalt |
|-------|--------|
| `Main Menu` | Startbildschirm mit Highscore-Anzeige |
| `CharacterSelection` | Charakter-Auswahl |
| `Tutorial` | Geführter Einstieg |
| `Level1` | Erstes Level |
| `Level2` | Zweites Level inkl. Boss-Fight |

## Steuerung

Standard Jump'n'Run-Layout — Bewegung mit den Pfeiltasten / WASD, Springen mit Space. Power-Ups werden über die UI-Buttons ausgelöst, sobald genug Münzen gesammelt sind.

## Tech Stack

- **Engine:** Unity `2021.3.25f1`
- **Sprache:** C#
- **Rendering:** 2D mit Parallax-Layern
- **UI:** TextMesh Pro

## Projektstruktur

```
Assets/
├── Character/        # Spieler-Sprites (PSB) + Animationen
├── Level/            # Unity-Szenen (Menu, Tutorial, Level1, Level2 …)
├── Pictures/         # UI-Grafiken, Coins, Hearts, Lehrer-Sprites
├── World/            # Tiles, Borders, Tische
└── Scripts/
    ├── Player/       # Movement, Health, PowerUps, Save/Load
    ├── Boss/         # Boss-Logik, Attacken, UI
    ├── BG/           # Parallax & Repeating Backgrounds
    └── Tutorial/     # Tutorial-Sequenzen
```

## Lokal starten

1. Repo clonen
2. In Unity Hub mit Version `2021.3.25f1` öffnen
3. Szene `Assets/Level/Main Menu.unity` laden
4. Play drücken

## Status

Schulprojekt — fertig spielbar inkl. Tutorial, beider Level und Boss-Fight.

---

<div align="center">

*Made with Unity und einer Prise Schulwahnsinn.*

</div>
