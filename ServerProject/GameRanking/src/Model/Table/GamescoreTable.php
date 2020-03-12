<?php
namespace App\Model\Table;

use Cake\ORM\Query;
use Cake\ORM\RulesChecker;
use Cake\ORM\Table;
use Cake\Validation\Validator;

/**
 * Gamescore Model
 *
 * @method \App\Model\Entity\Gamescore get($primaryKey, $options = [])
 * @method \App\Model\Entity\Gamescore newEntity($data = null, array $options = [])
 * @method \App\Model\Entity\Gamescore[] newEntities(array $data, array $options = [])
 * @method \App\Model\Entity\Gamescore|false save(\Cake\Datasource\EntityInterface $entity, $options = [])
 * @method \App\Model\Entity\Gamescore saveOrFail(\Cake\Datasource\EntityInterface $entity, $options = [])
 * @method \App\Model\Entity\Gamescore patchEntity(\Cake\Datasource\EntityInterface $entity, array $data, array $options = [])
 * @method \App\Model\Entity\Gamescore[] patchEntities($entities, array $data, array $options = [])
 * @method \App\Model\Entity\Gamescore findOrCreate($search, callable $callback = null, $options = [])
 */
class GamescoreTable extends Table
{
    /**
     * Initialize method
     *
     * @param array $config The configuration for the Table.
     * @return void
     */
    public function initialize(array $config)
    {
        parent::initialize($config);

        $this->setTable('gamescore');
        $this->setDisplayField('Id');
        $this->setPrimaryKey('Id');
    }

    /**
     * Default validation rules.
     *
     * @param \Cake\Validation\Validator $validator Validator instance.
     * @return \Cake\Validation\Validator
     */
    public function validationDefault(Validator $validator)
    {
        $validator
            ->integer('Id')
            ->allowEmptyString('Id', null, 'create');

        $validator
            ->integer('Score')
            ->requirePresence('Score', 'create')
            ->notEmptyString('Score');

        $validator
            ->date('Day')
            ->requirePresence('Day', 'create')
            ->notEmptyDate('Day');

        return $validator;
    }
}
