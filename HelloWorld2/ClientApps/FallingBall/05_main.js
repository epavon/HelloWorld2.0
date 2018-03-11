// 
// The orchestrator, the puppeteer, will use objects to create and drive the show

var canvas = document.getElementById('canvas');
var context = canvas.getContext('2d'); 

var ball;
var gameLoop = new GameLoop(canvas, update, draw);

window.onload = init; 

function init() {
	ball = new Ball(20,1,'#ff0000');
	ball.pos = new Vector2(150,50);
	ball.vel = new Vector2(50,40);
	ball.draw(context);

	gameLoop.start();
};

//
// All update code
function update(dt) {
	var elapsedTimeInSeconds = dt * 0.001;
	ball.pos = ball.pos.add(ball.vel.multiply(elapsedTimeInSeconds));		
}

//
// All drawing code
function draw() {
	context.clearRect(0, 0, canvas.width, canvas.height);
	ball.draw(context);
}



