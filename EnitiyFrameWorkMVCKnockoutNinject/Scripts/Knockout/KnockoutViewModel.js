
var ViewModel = function (knockoutRepository) {
    var self = this;
    self.Skills = ko.observableArray([]);
    self.IsEdit = ko.observable(false);
    self.SkillNameToEdit = ko.observable();
    self.SkillIdToEdit = ko.observable();

    Skill = function (data) {
        var self = this;
        self.SkillId = ko.observable(data.SkillId);
        self.SkillName = ko.observable(data.SkillName);
    };

    self.knockoutRepository = knockoutRepository;
    self.knockoutRepository.Get(self.Skills, self.errorCallBack);

    //Methods
    self.SaveSkill = function (item) {

        if (!item.SkillIdToEdit() > 0) {
            self.knockoutRepository.CreateSkill(item, self.SaveCreateSkill, self.errorCallBack);
        }
        else {
            self.knockoutRepository.EditSkill(item, self.SaveEditSkill, self.errorCallBack);
        }
    };

    self.DeleteSkill = function (item) {

        self.knockoutRepository.DeleteSkill(item, self.SaveDeleteSkill, self.errorCallBack);
    }
    //end of Methods

    self.CreateSkill = function (item) {
        if (self.IsEdit()) {
            self.IsEdit(false)
            self.SkillNameToEdit('');
            self.SkillIdToEdit('');
        } else {
            self.IsEdit(true);
            self.SkillNameToEdit('');
            self.SkillIdToEdit('');
        }
    }

    self.EditSkill = function (item) {

        if (self.IsEdit()) {
            self.IsEdit(false)
            self.SkillNameToEdit('');
            self.SkillIdToEdit('');
        } else {
            self.IsEdit(true);
            self.SkillNameToEdit(item.SkillName());
            self.SkillIdToEdit(item.SkillId());
        }
    }

    self.SaveDeleteSkill = function (item) {

        var skill = new Skill(item);

        $.each(self.Skills(), function (idx, o) {

            if (skill.SkillId() === o.SkillId()) {
                console.log('Delete: ' + o.SkillId())
                self.Skills.splice(idx, 1)
            }
        });

        var skillRef = new Firebase('https://glaring-fire-3869.firebaseio.com/skills/' + skill.SkillId());
        skillRef.remove();
    };

    self.SaveEditSkill = function (item) {
        self.IsEdit(false);

        var skill = new Skill(item);

        console.log('item to be updated: ' + skill.SkillId());

        $.each(self.Skills(), function (idx, o) {
            if (skill.SkillId() === o.SkillId()) {
                console.log('update: ' + o.SkillId())
                self.Skills.splice(idx, 1)
            }
        });

        self.Skills.push(skill);

        var skillRef = new Firebase('https://glaring-fire-3869.firebaseio.com/skills/' + skill.SkillId());
        skillRef.update({ skillId: skill.SkillId(), skillName: skill.SkillName() })
    }

    self.SaveCreateSkill = function (item) {

        var skill = new Skill(item);

        console.log('Create: ' + skill.SkillId());
        self.Skills.push(skill);
        self.IsEdit(false);
        var skillRef = new Firebase('https://glaring-fire-3869.firebaseio.com/skills/' + skill.SkillId());
        skillRef.set({ skillId: skill.SkillId(), skillName: skill.SkillName() })
    }

    self.CancelEdit = function (item) {
        item.IsEdit(false);
    }

    self.errorCallBack = function (message) {
        alert(message);
    };
}