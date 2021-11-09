
sintomade(tos,gripe).
sintomade(malestargeneral,gripe).
sintomade(dolorgarganta,gripe).
sintomade(dolorcabeza,gripe).
sintomade(congestionnasal,gripe).

sintomade(fiebre,gripeA).
sintomade(dolorcabeza,gripeA).
sintomade(dolormuscular,gripeA).
sintomade(congestionnasal,gripeA).
sintomade(dolorgarganta,gripeA).
sintomade(tos,gripeA).

sintomade(perdidaapetito,anemia).
sintomade(nauseas,anemia).
sintomade(vomito,anemia).
sintomade(cansancio,anemia).
sintomade(dificultadrespirar,anemia).

sintomade(fiebre,rubeola).
sintomade(escalofrios,rubeola).
sintomade(dolorcabeza,rubeola).
sintomade(ojosrojos,rubeola).

sintomade(dolormuscular,dengue).
sintomade(dolorcabeza,dengue).
sintomade(vomito,dengue).
sintomade(erupcionespiel,dengue).
sintomade(dolorarticulacion,dengue).

sintomade(dolorpecho,neumonia).
sintomade(tosconstante,neumonia).
sintomade(fiebreescalofrios,neumonia).
sintomade(dificultadrespirar,neumonia).

sintomade(tosseca,covid).
sintomade(cansancio,covid).
sintomade(fiebre,covid).
sintomade(dolormuscular,covid).
sintomade(dolorgarganta,covid).
sintomade(perdidagustoolfato,covid).
sintomade(dificultadrespirar,covid).

enfermedadde(Z,S):-sintomade(S,Z).




