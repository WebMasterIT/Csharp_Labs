{
  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = {
    nixpkgs,
    flake-utils,
    ...
  }:
    flake-utils.lib.eachDefaultSystem (
      system: let
        pkgs = import nixpkgs {inherit system;};
        pythonEnv = pkgs.python312.withPackages (ps:
          with ps; [
            catppuccin
            pygments
          ]);

        program = pkgs.writeShellScript "make.sh" ''
          export PYTHONPATH="${pythonEnv}:$PYTHONPATH:${pythonEnv}/${pythonEnv.sitePackages}"

          THEME_LIST=("dark" "light")

          for i in {2..7}; do
              cp -r ./"''${i}"lab/fig .
              for j in "''${THEME_LIST[@]}"; do
                  latexmk --lualatex --shell-escape "./''${i}lab/lab''${i}Handbook_''${j}.tex"
                  mv "lab''${i}Handbook_''${j}.pdf" "../Лабораторная работа №''${i} (''${j}).pdf"
                  rm -rf ./*.aux* ./*.log ./*.out ./*.fls ./*.fdb* ./*.lol ./*.toc ./_minted ./*.synctex* *minted*
              done
              rm -rf ./fig ./*/*.aux ./*/*.log ./*/*.out ./*/*.fls ./*/*.fdb* ./*/*.lol ./*/*.toc ./*/*.pdf ./*/*.synctex* ./*/*minted*
          done
        '';
      in {
        packages = pythonEnv;

        apps.default = {
          type = "app";
          program = "${program}";
        };
      }
    );
}
