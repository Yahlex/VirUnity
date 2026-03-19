# 🦠 VirUnity

![Unity](https://img.shields.io/badge/Unity-6000.0.x-black?style=flat-square&logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg?style=flat-square)

**VirUnity** est un jeu 3D où vous incarnez un virus informatique s'infiltrant dans un système sécurisé. Pénétrez le réseau, passez de salle en salle et affrontez les défenses pour corrompre la machine de l'intérieur.

## 🎮 Le Concept

L'infiltration se fait étape par étape :
- **Niveau 1 (Combat)** : Affrontez un Proxy de sécurité. Choisissez stratégiquement votre arme et détruisez-le avant d'être submergé par ses attaques.
- **Niveau 2 (Furtivité)** : Frayez-vous un chemin dans une baie de serveurs sans vous faire repérer. Volez une clé SSH et atteignez la sortie en mode "stealth".

## 🛠 Stack Technique

- **Moteur** : Unity 3D Core (version 6000.0.x)
- **Langage** : C#
- **IDE** : VS Code
- **Versioning** : Git / GitHub

## 🌿 Structure des Branches

Pour garder un projet propre, nous utilisons l'architecture suivante :

- `main` : Version stable et jouable.
- `dev` : Branche d'intégration principale des nouvelles fonctionnalités.
- `scene/menu-selection` : Création de l'écran titre et choix du virus.
- `scene/niveau-1-proxy` : Développement du niveau 1 (Combat).
- `scene/niveau-2-stealth` : Développement du niveau 2 (Infiltration).

## 🚀 Comment contribuer (Workflow Git)

Pour participer au projet, suivez ces 4 étapes simples :

1. **Créer une branche** depuis `dev` : `git checkout -b feature/votre-fonctionnalite`
2. **Développer et commiter** vos changements : `git commit -m "Ajout de ma fonctionnalité"`
3. **Pousser la branche** : `git push origin feature/votre-fonctionnalite`
4. **Ouvrir une Pull Request** (PR) vers `dev` sur GitHub.

> ⚠️ **AVERTISSEMENT CRITIQUE** : Ne commitez **JAMAIS** le dossier `Library/` ni aucun fichier temporaire généré par Unity (`Logs/`, `Temp/`, `Obj/`). Vérifiez toujours que votre `.gitignore` est fonctionnel avant de commit !
