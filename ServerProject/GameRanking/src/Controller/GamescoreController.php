<?php
namespace App\Controller;

use App\Controller\AppController;

/**
 * Gamescore Controller
 *
 * @property \App\Model\Table\GamescoreTable $Gamescore
 *
 * @method \App\Model\Entity\Gamescore[]|\Cake\Datasource\ResultSetInterface paginate($object = null, array $settings = [])
 */
class GamescoreController extends AppController
{
    /**
     * Index method
     *
     * @return \Cake\Http\Response|null
     */
    public function index()
    {
        $gamescore = $this->paginate($this->Gamescore);

        $this->set(compact('gamescore'));
    }

    /**
     * View method
     *
     * @param string|null $id Gamescore id.
     * @return \Cake\Http\Response|null
     * @throws \Cake\Datasource\Exception\RecordNotFoundException When record not found.
     */
    public function view($id = null)
    {
        $gamescore = $this->Gamescore->get($id, [
            'contain' => []
        ]);

        $this->set('gamescore', $gamescore);
    }

    /**
     * Add method
     *
     * @return \Cake\Http\Response|null Redirects on successful add, renders view otherwise.
     */
    public function add()
    {
        $gamescore = $this->Gamescore->newEntity();
        if ($this->request->is('post')) {
            $gamescore = $this->Gamescore->patchEntity($gamescore, $this->request->getData());
            if ($this->Gamescore->save($gamescore)) {
                $this->Flash->success(__('The gamescore has been saved.'));

                return $this->redirect(['action' => 'index']);
            }
            $this->Flash->error(__('The gamescore could not be saved. Please, try again.'));
        }
        $this->set(compact('gamescore'));
    }

    /**
     * Edit method
     *
     * @param string|null $id Gamescore id.
     * @return \Cake\Http\Response|null Redirects on successful edit, renders view otherwise.
     * @throws \Cake\Datasource\Exception\RecordNotFoundException When record not found.
     */
    public function edit($id = null)
    {
        $gamescore = $this->Gamescore->get($id, [
            'contain' => []
        ]);
        if ($this->request->is(['patch', 'post', 'put'])) {
            $gamescore = $this->Gamescore->patchEntity($gamescore, $this->request->getData());
            if ($this->Gamescore->save($gamescore)) {
                $this->Flash->success(__('The gamescore has been saved.'));

                return $this->redirect(['action' => 'index']);
            }
            $this->Flash->error(__('The gamescore could not be saved. Please, try again.'));
        }
        $this->set(compact('gamescore'));
    }

    /**
     * Delete method
     *
     * @param string|null $id Gamescore id.
     * @return \Cake\Http\Response|null Redirects to index.
     * @throws \Cake\Datasource\Exception\RecordNotFoundException When record not found.
     */
    public function delete($id = null)
    {
        $this->request->allowMethod(['post', 'delete']);
        $gamescore = $this->Gamescore->get($id);
        if ($this->Gamescore->delete($gamescore)) {
            $this->Flash->success(__('The gamescore has been deleted.'));
        } else {
            $this->Flash->error(__('The gamescore could not be deleted. Please, try again.'));
        }

        return $this->redirect(['action' => 'index']);
    }

    public function getScore(){
        error_log("getScore()");
        $this->autoRender = false;
        
        $query = $this->Gamescore->find('all');
              $query->order(['score' => 'DESC']);       //カラム['score']をキーにして昇順ソート
              $query->limit(5);                    //表示個数を5つに絞る    
        //クエリを実行してarrayにデータを格納
        $json_array = json_encode($query);
        //---------------
        // $json_array の内容を出力
        echo $json_array;
    }

    public function setScore(){
        error_log("setScore()");
        $this->autoRender = false;
        $score = 0;
        if( isset( $this->request->data['Score'] ) ){
            $score   = $this->request->data['Score'];
            error_log($score);
        }
        
        //---------------
        //テーブルに追加するレコード情報を作る
        $data   = array ( 'Score' => $score, 'Day' => date('Y/m/d') );   //Date型
        $gameScore = $this->Gamescore->newEntity();
        $gameScore = $this->Gamescore->patchEntity($gameScore, $data);
        if ($this->Gamescore->save($gameScore)) {
            //追加成功
            echo "success"; //success!
        }else{
            //追加失敗
            echo "failed"; //failed!
        }      
    }
}
