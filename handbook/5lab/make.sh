#!/usr/bin/env bash

# TODO: this is not work :)

TEX_LIST=("lab5Handbook_dark.tex" "lab5Handbook_light.tex")
MINTED_OPTS="-shell-escape -interaction=nonstopmode"

for TEX_FILE in "${TEX_LIST[@]}"; do
    lualatex "$MINTED_OPTS" "$TEX_FILE"
done

rm -f ./*.aux ./*.log ./*.out* ./_minted* ./*.pyg
