import States

class Context:
    
    def __init__(self):
        self.currentState = States.StateToDo()

    def action(self):
        self.currentState.action(self)
        
    def actionBack(self):
        self.currentState.actionBack(self)