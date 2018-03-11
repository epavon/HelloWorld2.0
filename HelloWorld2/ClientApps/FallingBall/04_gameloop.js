function GameLoop(canvas, update, draw) {	
	this.update = update;
	this.draw = draw;
	this.canvas = canvas;
	this.timeOnLastFrame = 0;
		
}

//
// Public Methods
GameLoop.prototype = {
	animateFrame: function (totalTimeElapsed) {
			var elapsedTime = totalTimeElapsed - this.timeOnLastFrame;			
			this.timeOnLastFrame = totalTimeElapsed;			
			this.update(elapsedTime);
			this.draw();
			window.requestAnimationFrame(this.animateFrame.bind(this), canvas);
	},
	start: function() {
		window.requestAnimationFrame(this.animateFrame.bind(this), canvas);
	}
}
