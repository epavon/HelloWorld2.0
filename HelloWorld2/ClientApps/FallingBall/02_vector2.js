function Vector2 (x,y) {
	this.x = x;
	this.y = y;		
}	

// PUBLIC METHODS	
Vector2.prototype = {
	lengthSquared: function(){
		return this.x*this.x + this.y*this.y;
	},
	length: function(){
		return Math.sqrt(this.lengthSquared());
	},	
	add: function(b) {
		return new Vector2(this.x + b.x, this.y + b.y);
	},
	subtract: function(b) {
		return new Vector2(this.x - b.x,this.y - b.y);
	},
	negate: function() {
		return new Vector2(-this.x, -this.y);
	},
	multiply: function(k) {
		return new Vector2(k*this.x,k*this.y);
	},
	dotProduct:	function(b) {
		return this.x*b.x + this.y*b.y;
	},
	normalize: function() {
		var length = this.length();
		if (length > 0) {
			this.x /= length;
			this.y /= length;
		}
		return this.length();
	},	
	
};

// STATIC METHODS
Vector2.distance =  function(vec1,vec2){
	return (vec1.subtract(vec2)).length(); 
}
Vector2.angleBetween = function(vec1,vec2){
	return Math.acos(vec1.dotProduct(vec2)/(vec1.length()*vec2.length()));
}
