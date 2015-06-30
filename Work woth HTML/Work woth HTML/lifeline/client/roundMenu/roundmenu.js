/**
 * Created by Shturmin on 31.03.14.
 */


Template.roundMenu.rendered = function(){
    if(Session.get('editindActivity')) {
        var data = Session.get('editindActivity');
        var actId = data[0];
        var x = data[2];
        var y = data[1];
        jQuery('.round-menu').css({
            'left' : x+'px',
            'top' : y+'px'
        });
    }
};

Template.roundMenu.events = {
     'click .round-menu' : function(){
         Session.set('editindActivity',false);
     }
}