TESTLOL_project
===============

jeu

- Changement de Map :

      Script d'entrée et de sortie applicable à un BoxCollider. Quand le player entre, il est redirigé vers la map            correspondante. Chaque map est une nouvelle scène?

- Map globale :

      Un système de map global pourrait être intéressant (une map que le player peut visualiser à partir de son menu,         par exemple). Il pourrait voir l'Area à mesure qu'il la découvre (ou peut-être même la région?). Ça pourrait            fonctionner comme une grille, une matrice nullable binaire. Chaque entrée vaut 'null' par défaut, si visité, elle       vaut 0 et si complétée elle vaut 1 (sinon, pas besoin de null, 0 si pas visité, 1 sinon).

- Sauter pour changer d'étage :

      Un chaque object de plancher a un BoxCollider et l'object est taggé "floor". Chaque "floor" est sur son propre          layer et sauter fait monter de un layer.
      
- Collision :

      On peut sauter par dessus les objects de tag "dynamic" mais pas ceux de tag "static". Si on atterit sur un object       dynamic, chaque object (le player et le dynamique) s'entre-pousse dans la direction opposée de la collision.            Chaque object pourrait avoir une masse qui détermine à quel point il est difficile à pousser par des object de          masse plus petite. Certains objects dynamiques porrait avoir une masse infinie ou très grande (un boss, par             exemple).

- Hiréarchie et nomenclature des Maps :

      Monde > Régions (La forêt enchantée, régions enneigée, etc.) > Areas (amas de pièce d'un donjon, d'une grotte,          village, etc.) > Maps (scène composé d'ennemis). 

- block

- plusieurs armes (un arbre à skill par arme)

- bcp de skills (arbre à skills pour le perso, incluant dodge et bcp de mouvements)

- combat qui requiert du talent (difficile) en plus d'éléments aléatoires

- histoire et univers à déterminer

- multiplayer coop et pvp

- coop (camera suit les 2, les 2 restent ensemble, même camera, jeu plus dûr)

- pvp (1v1, 2v2, xvx)

- points de stats à travers les skills (lvl up = choisir skills, skills = action + stats)

- types d'Attaques = juste des skills (pas vrmt d'atk de base)

- choix du sexe
