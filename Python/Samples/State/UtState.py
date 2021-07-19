import unittest
import Context


class UtState(unittest.TestCase):

    def test_state(self):
        expectedFinalState = "Done(已完成)"
        actualFinalState = ""

        context = Context.Context()
        hasDefect=0
        while (context.currentState != None):
            actualFinalState = str(context.currentState)
            print("需求目前狀態="+ actualFinalState)
            #主程式(回到上一個狀態)
            if(hasDefect==2): # StateTesting(第一次測試失敗)
                context.actionBack()   
            else: 
                context.action()
            hasDefect+=1

        
        
        self.assertEqual(actualFinalState, expectedFinalState)



if __name__ == '__main__':
    unittest.main()
