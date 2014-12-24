var KnockoutRepository = function () {
    var self = this;
    self.dataType = 'json';
    self.target = '/api/Skills';

    self.Get = function (skills, errorCallBack) {
        $.ajax(self.target, {
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                ko.mapping.fromJS(data, {}, skills);
            },
            error: function (error) {
                errorCallBack('read');
            },
            dataType: self.dataType
        });

        //var skillRef = new Firebase('https://glaring-fire-3869.firebaseio.com/skills');
        //ko.mapping.fromJS(skillRef, {}, skills);
    };

    self.CreateSkill = function (item, successCallBack, errorCallBack) {
        var newSkill = {};
        newSkill.SkillId = item.SkillIdToEdit();
        newSkill.SkillName = item.SkillNameToEdit();

        if (!newSkill.SkillId) {
            $.ajax(self.target, {
                type: "POST",
                cache: false,
                contentType: 'application/json; charset=utf-8',
                data: ko.mapping.toJSON(newSkill),
                success: function (data) {
                    successCallBack(data);
                },
                error: function (error) {
                    errorCallBack('create');
                },
                dataType: self.dataType
            });
        }
        else {
            alert('Cant create this item');
        }
    };

    self.EditSkill = function (item, successCallBack, errorCallBack) {
        var newSkill = {};
        newSkill.SkillId = item.SkillIdToEdit();
        newSkill.SkillName = item.SkillNameToEdit();

        if (newSkill.SkillId) {
            $.ajax(self.target + "/" + newSkill.SkillId, {
                type: "PUT",
                cache: false,
                contentType: 'application/json; charset=utf-8',
                data: ko.mapping.toJSON(newSkill),
                success: function (data) {
                    successCallBack(data);
                },
                error: function (error) {
                    errorCallBack('edit');
                },
                dataType: self.dataType
            });
        }
        else {
            alert('Cant edit this item');
        }
    };

    self.DeleteSkill = function (item, successCallBack, errorCallBack) {
        $.ajax(self.target + "/" + item.SkillId(), {
            type: "DELETE",
            cache: false,
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                successCallBack(data);
            },
            error: function (error) {
                errorCallBack('delete');
            }
        });
    };

};