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

- Unity Engine (versão testada: **6000.1.5f1**)
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
3. Navegue até `Assets/_Project/Scenes/` e crie a cena inicial `MainMenu.unity` (ou execute-a se já existir).

## ▶️ Testando no Unity

1. Abra o projeto no **Unity 6000.1.5f1**.
2. Aguarde o Package Manager instalar os pacotes descritos em `Packages/manifest.json`.
3. Abra uma das cenas em `Assets/_Project/Scenes/` (por exemplo `MainMenu.unity` ou `TesteJogabilidade.unity`).
4. Em **File > Build Settings...** clique em **Add Open Scenes** para garantir que a cena seja carregada na build.
5. Pressione **Play** para iniciar o modo de jogo.

### 🎯 Configurando o prefab do jogador

1. Crie um objeto jogador na cena e adicione os scripts localizados em `Assets/_Project/Scripts/Player/`.
2. Após ajustar componentes como `Rigidbody2D` e colliders, arraste o objeto para `Assets/_Project/Prefabs/Characters/` para salvar como `Player.prefab`.
3. Coloque esse prefab nas cenas de teste para validar os controles e a lógica do jogo.

## 🔄 Git Ignore

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

## 📄 Licença

Projeto de uso acadêmico e educacional.  
Todos os direitos reservados aos autores citados neste documento.

