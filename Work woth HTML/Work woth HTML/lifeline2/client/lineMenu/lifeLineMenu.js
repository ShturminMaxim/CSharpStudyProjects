Template.lifeLineMenu.events = {
	'click .add-daily':function(){
		Session.set('addingNewActivity', 'daily');
	},
	'click .add-custom':function(){
		Session.set('addingNewActivity', 'custom');
	},
	'click ':function(){

	}
}