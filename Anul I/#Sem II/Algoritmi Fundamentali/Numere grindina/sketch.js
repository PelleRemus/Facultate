//let nn,nnRev;
let i = 0;
//let rnd;
let nr;

function setup() {
//        nn = new NeuralNetwork(1, 2, 1);
	i = 0; 
}
function draw()
{
	for (let j = 0; j < 2000; j++) {
		i += 0.0000000000000001; 
		nr = decInput(0.4985037783225721-i);
		if(getNrPasi(nr)>1810)
			console.log(nr,getNrPasi(nr));

		nr = decInput(0.4985037783225721+i);
		if(getNrPasi(nr)>1810)
			console.log(nr,getNrPasi(nr));
	}

        /*for (let i = 0; i < 100; i++) {

                rnd = Math.round(random(500000000000000, 1000000000000000));
                let data = [
                        encPasi(getNrPasi(rnd),rnd),
                        encInput(rnd)
                ]; 
                nn.train([data[0]], [data[1]]);
        }*/
}
function magie(nrPasi){
        let q = nn.predict([nrPasi]);
        q = decInput(q);
        console.log("Numarul este: ",q);
        console.log(q," numarul de pasi adevarati: ",getNrPasi(q));

}
function compare(nr = 0) {
        if (nr == 0)
                nr = Math.round(random(500000000000000, 1000000000000000));
        let guess = decPasi(nn.predict([encInput(nr)]), nr);
        console.log(nr, getNrPasi(nr), guess);
}

function getNrPasi(n) {
        let i = n;
        let p = 0;
        do {
                p++;
                if (n % 2 == 0)
                        n = n / 2;
                else
                        n = n * 3 + 1;
        } while (n != 1);
        if (p >= 1810)
                console.log("L-am gasit: ", i);
        return p;
}


function encInput(inp) {
        return (inp- 500000000000000) / 499999999999999;
}

function decInput(val) {
        return (val * 499999999999999) + 500000000000000;
}

function encPasi(val, nr) {
        return val / nr;
}

function decPasi(val, nr) {
        return val * getNrPasi(nr);
}