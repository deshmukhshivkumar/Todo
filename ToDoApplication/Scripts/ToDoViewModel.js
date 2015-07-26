function ToDoViewModel(title, description, email, priority) {
    var self = this;
    self.title = title || "";
    self.description = description || "";
    self.email = email || "";
    self.priority = priority || "";
}

    /*
     1.Title Required, StringLength (100) 
     2. Description StringLength (1000)
     3. Mail To Presence, EmailsOnly 
     4. Priority Range(1 - 5)
    */