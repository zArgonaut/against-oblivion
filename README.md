# 🎮 Against Oblivion

Projeto de desenvolvimento de jogo em primeira pessoa (FPS) com múltiplas fases, implementado como trabalho da disciplina de **Computação Gráfica** — Universidade Federal Rural do Rio de Janeiro (UFRRJ).

## 📘 Descrição

**Against Oblivion** é um jogo de luta e sobrevivência ambientado em um mundo pós-apocalíptico. O jogador deve enfrentar hordas de monstros, coletar itens, aprimorar suas armas e derrotar minibosses até alcançar o Boss final — líder de uma legião tecnológica que domina o planeta.

## 🧠 Disciplina

- **Curso:** Ciência da Computação  
- **Disciplina:** Computação Gráfica  
- **Instituição:** Universidade Federal Rural do Rio de Janeiro (UFRRJ)  
- **Professora:** [Nome da professora, se desejar incluir]  
- **Período:** [Semestre e ano do curso, ex: 2025.1]  

## 👥 Integrantes

- Caio Almeida de Souza  
- Gustavo Marinho Guimarães  
- Maicom Howie Guimarães da Silva

## 🎮 Mecânicas e Tecnologias

- FPS com fases progressivas e minibosses  
- Sistema de pontuação e upgrade de armas  
- Inventário com gerenciamento de munições e itens  
- Efeitos visuais via sistemas de partículas  
- Terrenos gerados proceduralmente  
- Clima dinâmico: chuva, neve, poeira  
- Combate corpo-a-corpo e à distância  
- Ciclo de vida, energia e níveis de progressão  

## 🛠️ Tecnologias Utilizadas

- Unity Engine  
- C# (scripts de lógica e controle)  
- Shader Graph / Sistema de partículas  
- Blender (modelagem 3D de personagens e ambientes)  
- Git e GitHub para versionamento  

## 🚧 Estrutura do Projeto Unity

```
Assets/
├── _Project/
│   ├── Scenes/
│   ├── Scripts/
│   ├── Prefabs/
│   ├── Materials/
│   ├── Audio/
│   ├── Animations/
│   ├── UI/
│   └── Art/
├── Plugins/
├── Resources/
```

## ✅ Como começar

1. Clone este repositório:
   ```bash
   git clone https://github.com/zArgonaut/against-oblivion.git
   ```
2. Abra com o Unity.
   - Requer Unity na versão 6000.1.5f1 (verifique em `ProjectSettings/ProjectVersion.txt`).
3. Navegue até `Assets/_Project/Scenes/` e crie a cena inicial `MainMenu.unity` (ou execute-a se já existir).


Este projeto já vem com um `.gitignore` configurado para projetos Unity, evitando que arquivos desnecessários sejam versionados (como `Library/`, `Temp/`, `Build/`, entre outros).

---

## 🚀 Workflow de Desenvolvimento em Equipe

Para garantir organização e evitar conflitos no projeto, adotaremos as seguintes práticas de versionamento com Git:

### 🔧 Criação de branch por desenvolvedor

Cada integrante deve trabalhar em uma branch separada:

```bash
git checkout -b nome-do-integrante
```

### 💾 Commits e push

Após concluir um conjunto de tarefas:

```bash
git add .
git commit -m "✨ Descrição do que foi desenvolvido"
git push origin nome-do-integrante
```

### 🔁 Pull Requests

Quando o recurso estiver estável:

1. Vá até a aba **Pull Requests** no GitHub  
2. Clique em **New Pull Request**  
3. Selecione `base: main` e `compare: sua-branch`  
4. Descreva as mudanças e envie para revisão  
5. Após aprovação, faça o merge  

### 🧼 Atualizar sua branch com o que há na `main`

Para evitar conflitos:

```bash
git checkout main
git pull origin main
git checkout sua-branch
git merge main
```

### ⚠️ Cuidados com o Unity

- Evite trabalhar simultaneamente na mesma cena `.unity`
- Nunca delete diretórios ou arquivos sem combinar com o time
- Evite mexer diretamente em arquivos `.meta`

---
## Jogando

Abra `Assets/_Project/Scenes/MainMenu.unity` no Unity e pressione Play. O progresso segue pelas fases e retorna ao menu ao final.

## Contribuindo

Scripts ficam em `Assets/_Project/Scripts`. Para adicionar inimigos crie um prefab em `Prefabs` e registre no `HordaManager`.

## 🆕 Atualizações

- Corrigido o suavização da câmera multiplicando a suavidade por `Time.deltaTime`.
- Arquivo `ignore.conf` removido e todas as regras migradas para `.gitignore`.


## 📄 Licença

Projeto de uso acadêmico e educacional.
Todos os direitos reservados aos autores citados neste documento.

