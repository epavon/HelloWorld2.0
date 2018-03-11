
function Ball(radius, mass, color) {
	if(typeof(radius)==='undefined') radius = 20;
	if(typeof(mass)==='undefined') mass = 1;
	if(typeof(color)==='undefined') color = '#0000ff';
	this.radius = radius;
	this.color = color;
	this.mass = mass;
	this.pos = new Vector2(0,0);
	this.vel = new Vector2(0,0);
}

Ball.prototype = Object.create(Particle.prototype);
Ball.prototype.constructor = Ball;

Ball.prototype.draw = function (context){	
	var grad = context.createRadialGradient(this.x,this.y,0,this.x,this.y,this.radius);
	grad.addColorStop(0,'#ffffff');
	grad.addColorStop(1,this.color);
	context.fillStyle = grad;
		
	context.beginPath();
	context.arc(this.x, this.y, this.radius, 0, 2*Math.PI, true);
	context.closePath();
	context.fill();		
};


