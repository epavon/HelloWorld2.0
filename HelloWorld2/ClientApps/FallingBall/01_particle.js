// dependencies: Vector2
function Particle(mass,charge){
	if(typeof(mass)==='undefined') mass = 1;
	if(typeof(charge)==='undefined') charge = 0;		
	this.mass = mass;
	this.charge = charge;	
	this.pos = new Vector2(0,0);
	this.vel = new Vector2(0,0);
	this.acc = new Vector2(0,0);
}		

Particle.prototype = {	
	get x () {
		return this.pos.x;
	},
	get y () {
		return this.pos.y;
	}
};