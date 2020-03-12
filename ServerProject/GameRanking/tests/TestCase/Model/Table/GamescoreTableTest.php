<?php
namespace App\Test\TestCase\Model\Table;

use App\Model\Table\GamescoreTable;
use Cake\ORM\TableRegistry;
use Cake\TestSuite\TestCase;

/**
 * App\Model\Table\GamescoreTable Test Case
 */
class GamescoreTableTest extends TestCase
{
    /**
     * Test subject
     *
     * @var \App\Model\Table\GamescoreTable
     */
    public $Gamescore;

    /**
     * Fixtures
     *
     * @var array
     */
    public $fixtures = [
        'app.Gamescore'
    ];

    /**
     * setUp method
     *
     * @return void
     */
    public function setUp()
    {
        parent::setUp();
        $config = TableRegistry::getTableLocator()->exists('Gamescore') ? [] : ['className' => GamescoreTable::class];
        $this->Gamescore = TableRegistry::getTableLocator()->get('Gamescore', $config);
    }

    /**
     * tearDown method
     *
     * @return void
     */
    public function tearDown()
    {
        unset($this->Gamescore);

        parent::tearDown();
    }

    /**
     * Test initialize method
     *
     * @return void
     */
    public function testInitialize()
    {
        $this->markTestIncomplete('Not implemented yet.');
    }

    /**
     * Test validationDefault method
     *
     * @return void
     */
    public function testValidationDefault()
    {
        $this->markTestIncomplete('Not implemented yet.');
    }
}
