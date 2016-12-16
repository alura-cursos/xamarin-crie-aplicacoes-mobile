### Trabalhando com TableView ###

Qual das afirmações abaixo descreve o que é um `TableView`?

a. Permite arranjar views em linhas e colunas.
> Essa é a definição de um `Grid`

b. Organiza ("empilha") views em uma linha unidimensional, horizontal ou verticalmente.
> Essa é a definição de `StackLayout`

c. É uma view para apresentar listas de dados, especialmente listas longas que exigem rolagem.
> Essa é a definição de `ListView`

d. É uma view para exibir listas de configurações, formulários de dados ou dados cujo formato muda de linha para linha.

> CORRETO. Uma `TableView` é usado para:
>
> * apresentar uma lista de configurações,
> * coletar dados em um formulários ou
> * exibir dados que são apresentados de forma diferente em cada linha (ex: textos, números, porcentagens e imagens).

e. É usado para exibir conteúdo web e HTML na sua aplicação.
> Essa é a definição de WebView

### Entrada de Dados de Valores Boolean ###

Dentro de um `TableView`, qual o controle ideal para
coletar dados do tipo `boolean`?

> OPINIÃO DA ALURA:
> O `SwitchCell` é um controle `Cell` com um label
> e uma chave liga-desliga, ou seja, é o controle adequado
> para entrada de dados do tipo boolean.
> 

### Exibindo Texto Dentro De Um TableView ###

Selecione a alternativa com o código XAML correto para
se exibir um `TableView` com um texto simples e somente-leitura.

a. código
```
<TableView Intent="Settings">
    O uso deste aplicativo enquanto estiver andando na rua pode provocar atropelamento.
</TableView>
```

b. código
```
<TableView Intent="Settings">
    <TableRoot>
        <TableSection Title="Avisos">
            <Label Text="O uso deste aplicativo enquanto estiver andando na rua pode provocar atropelamento."/>
        </TableSection>
    </TableRoot>
</TableView>
```

c. código
```
<TableView Intent="Settings">
    <TextCell Text="O uso deste aplicativo enquanto estiver andando na rua pode provocar atropelamento."/>
</TableView>
```

d. código
```
<TableView Intent="Settings">
    <TableRoot>
        <TableSection Title="Avisos">
            <TextCell Text="O uso deste aplicativo enquanto estiver andando na rua pode provocar atropelamento."/>
        </TableSection>
    </TableRoot>
</TableView>
```

e. código
```
<TableView Intent="Settings">
    <TableRoot>
        <TableSection Title="Avisos">
            <Text Text="O uso deste aplicativo enquanto estiver andando na rua pode provocar atropelamento."/>
        </TableSection>
    </TableRoot>
</TableView>
```

> OPINIÃO DA ALURA: o controle `TextCell` é um controle `Cell` que pode exibir
> texto e detalhe (TextCell.Text e TextCell.Detail).

### Desenvolvendo Uma Tela de Configurações ###

Você é o desenvolvedor Xamarin de uma grande rede de fast-food. Seu
objetivo é desenvolver um aplicativo em que o cliente faz um pré-pedido
e escolhe os opcionais do hambúrguer Big Snack, que obrigatoriamente deve conter:
* pão com gergelim
* dois hambúrgueres 

Escolha a alternativa com o código XAML necessário para implementar
esses requisitos.

a. código

```
<StackLayout>
    <SwitchCell Text="Dois hambúrgueres" On="{Binding TemDoisHamburgueres}"/>
    <SwitchCell Text="Alface" On="{Binding TemAlface}"/>
    <SwitchCell Text="Queijo" On="{Binding TemQueijo}"/>
    <SwitchCell Text="Molho especial" On="{Binding TemMolhoEspecial}"/>
    <SwitchCell Text="Cebola" On="{Binding TemCebola}"/>
    <SwitchCell Text="Pickles" On="{Binding TemPickles}"/>
    <SwitchCell Text="Pão com gergelim" On="{Binding TemPaoComGergelim}"/>
<\StackLayout>
```
> O controle `SwitchCell`, assim como todos os controles `Cell`, deve estar contido 
> dentro de um `TableView`.
> 
b. código

```
<ListView>
  <ListView.ItemTemplate>
    <DataTemplate>
      <ViewCell>
        <StackLayout>
            <Switch Text="Dois hambúrgueres" On="{Binding TemDoisHamburgueres}"/>
            <Switch Text="Alface" On="{Binding TemAlface}"/>
            <Switch Text="Queijo" On="{Binding TemQueijo}"/>
            <Switch Text="Molho especial" On="{Binding TemMolhoEspecial}"/>
            <Switch Text="Cebola" On="{Binding TemCebola}"/>
            <Switch Text="Pickles" On="{Binding TemPickles}"/>
            <Switch Text="Pão com gergelim" On="{Binding TemPaoComGergelim}"/>
        </StackLayout>
      </ViewCell>
    </DataTemplate>
  </ListView.ItemTemplate>
</ListView>
```
> O controle `ListView` serve para repetição da visualização
> de dados partir de uma lista. Como não há lista de dados associado
> ao `ListView`, não faz sentido incluir os controles `Switch` no
> template do `ListView`.
> 
c. código

```
<TableView Intent="Settings">
    <TableRoot>
        <TableSection Title="Opcionais">
            <Switch Text="Dois hambúrgueres" On="{Binding TemDoisHamburgueres}"/>
            <Switch Text="Alface" On="{Binding TemAlface}"/>
            <Switch Text="Queijo" On="{Binding TemQueijo}"/>
            <Switch Text="Molho especial" On="{Binding TemMolhoEspecial}"/>
            <Switch Text="Cebola" On="{Binding TemCebola}"/>
            <Switch Text="Pickles" On="{Binding TemPickles}"/>
            <Switch Text="Pão com gergelim" On="{Binding TemPaoComGergelim}"/>
        </TableSection>
    </TableRoot>
</TableView>
```
> De acordo com os requisitos, os ingredientes "Dois hambúrgueres" e "Pão com gergelim" 
> não são opcionais, portanto não deveriam ser alterados pelo usuário, portanto não
> deveriam estar em controles `SwitchCell` habilitados.

d. código

```
<TableView Intent="Settings">
    <TableRoot>
        <TableSection Title="Big Snack">
            <TextCell Text="Dois hambúrgueres"/>
            <TextCell Text="Pão com gergelim"/>
        </TableSection>
        <TableSection Title="Opcionais">
            <SwitchCell Text="Alface" On="{Binding TemAlface}"/>
            <SwitchCell Text="Queijo" On="{Binding TemQueijo}"/>
            <SwitchCell Text="Molho especial" On="{Binding TemMolhoEspecial}"/>
            <SwitchCell Text="Cebola" On="{Binding TemCebola}"/>
            <SwitchCell Text="Pickles" On="{Binding TemPickles}"/>
        </TableSection>
    </TableRoot>
</TableView>
```
> CORRETO: Os ingredientes obrigatórios são somente-leitura estão em `TextCell`,
> enquanto os opcionais estão em `SwitchCell`.
> 
e. código

```
<TableView Intent="Settings">
    <TextCell Text="Dois hambúrgueres"/>
    <TextCell Text="Pão com gergelim"/>
    <SwitchCell Text="Alface" On="{Binding TemAlface}"/>
    <SwitchCell Text="Queijo" On="{Binding TemQueijo}"/>
    <SwitchCell Text="Molho especial" On="{Binding TemMolhoEspecial}"/>
    <SwitchCell Text="Cebola" On="{Binding TemCebola}"/>
    <SwitchCell Text="Pickles" On="{Binding TemPickles}"/>
</TableView>
```
Os controles `TextCell` e `SwitchCell` devem estar contidos
entro de um `TableRoot`.

