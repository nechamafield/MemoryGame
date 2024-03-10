namespace memorygame {
    let gameOver = false;
    let nextturn = false;
    let btn1: HTMLButtonElement;
    let btn2: HTMLButtonElement;
    let turnnumint = 1;
    let scorenumint = 1;
    let turnNumber: Element;
    turnNumber = document.querySelector("#turnnumber");
    let scoreNumber: Element;
    scoreNumber = document.querySelector("#scorenumber");
    let allSpots: HTMLButtonElement[] = [];
    allSpots = [...document.querySelectorAll<HTMLButtonElement>(".spot")];
    let spotsToMatch: Element[] = [];
    spotsToMatch = [...document.querySelectorAll(".spot")];
    const winningsets: Element[][] = [];
    let chunk = [];
    class colorclass { };

    let lstColorClasses: string[] = [];
    lstColorClasses.push('m1', 'm2', 'm3', 'm4', 'm5', 'm6', 'm7', 'm8', 'm9', 'm10', 'm11', 'm12', 'm13', 'm14', 'm15', 'm16', 'm17', 'm18');

    setMatchesRandomly();
    allSpots.forEach(s => s.addEventListener("click", takeSpot));

    startGame();

    function setMatchesRandomly() {
        let s = spotsToMatch.length;
        spotsToMatch.sort(() => Math.random() - 0.5);

        for (let i = 0; i < spotsToMatch.length; i += 2) {
            chunk = [spotsToMatch.slice(i, i + 2)];
            winningsets.push(...chunk);
        }
        console.log(winningsets);

        lstColorClasses.sort(() => Math.random() - 0.5);
        winningsets.forEach(function (set, index) { set.forEach(function (button) { button.setAttribute("color", lstColorClasses[index]) }) });
    }


    function startGame(){
        gameOver = false;
        nextturn = false;
        btn1 = null;
        btn2 = null;
        turnnumint = 1;
        scorenumint = 1;
        turnNumber.textContent = "0";
        scoreNumber.textContent = "0";
        allSpots.forEach(s => {
            s.classList.remove(s.getAttribute("color"));
            s.classList.remove("alreadyMatched");
            s.classList.add("notClicked");
            s.disabled = false;
        });
    }

    function colorfulClickRandom(btn: Element) {
        btn.classList.remove("notClicked");
        btn.classList.add(btn.getAttribute("color"));
    }


    function takeSpot(event: Event) {
        let btn = event.target as HTMLButtonElement;
        if (btn1 == null) {
            btn1 = btn;
            btn1.disabled = true;
        }
        else if (btn1 != null && btn2 == null) {
            btn2 = btn;
            btn2.disabled = true;
        }
        else {
            return;
        }
        doTakeSpot(btn);
    }


    function doTakeSpot(btn: Element) {
        if (btn.classList.contains("notClicked")) {
            colorfulClickRandom(btn);
        }
        if (btn.classList.contains("alreadyMatched")) {
            return;
        }
        if (btn2 != null) {
            (document.getElementById("btnNextTurn") as HTMLButtonElement).disabled = false;
        }
    }

    function nextTurn(): void{
        nextturn = true;
        turnNumber.textContent = (turnnumint++).toString();
        btn1.classList.remove(btn1.getAttribute("color"));
        btn2.classList.remove(btn2.getAttribute("color"));
        if (btn1.getAttribute("color") === btn2.getAttribute("color")) {
            btn1.classList.add("alreadyMatched");
            btn2.classList.add("alreadyMatched");
            scoreNumber.textContent = (scorenumint++).toString();
            btn1.disabled = true;
            btn2.disabled = true;
        }
        else {
            btn1.classList.add("notClicked");
            btn2.classList.add("notClicked");
            btn1.disabled = false;
            btn2.disabled = false;
        }
        (document.getElementById("btnNextTurn") as HTMLButtonElement).disabled = true;
        btn1 = null;
        btn2 = null;
    }
}