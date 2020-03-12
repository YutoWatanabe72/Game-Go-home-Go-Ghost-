<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Gamescore[]|\Cake\Collection\CollectionInterface $gamescore
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Html->link(__('New Gamescore'), ['action' => 'add']) ?></li>
    </ul>
</nav>
<div class="gamescore index large-9 medium-8 columns content">
    <h3><?= __('Gamescore') ?></h3>
    <table cellpadding="0" cellspacing="0">
        <thead>
            <tr>
                <th scope="col"><?= $this->Paginator->sort('Id') ?></th>
                <th scope="col"><?= $this->Paginator->sort('Score') ?></th>
                <th scope="col"><?= $this->Paginator->sort('Day') ?></th>
                <th scope="col" class="actions"><?= __('Actions') ?></th>
            </tr>
        </thead>
        <tbody>
            <?php foreach ($gamescore as $gamescore): ?>
            <tr>
                <td><?= $this->Number->format($gamescore->Id) ?></td>
                <td><?= $this->Number->format($gamescore->Score) ?></td>
                <td><?= h($gamescore->Day) ?></td>
                <td class="actions">
                    <?= $this->Html->link(__('View'), ['action' => 'view', $gamescore->Id]) ?>
                    <?= $this->Html->link(__('Edit'), ['action' => 'edit', $gamescore->Id]) ?>
                    <?= $this->Form->postLink(__('Delete'), ['action' => 'delete', $gamescore->Id], ['confirm' => __('Are you sure you want to delete # {0}?', $gamescore->Id)]) ?>
                </td>
            </tr>
            <?php endforeach; ?>
        </tbody>
    </table>
    <div class="paginator">
        <ul class="pagination">
            <?= $this->Paginator->first('<< ' . __('first')) ?>
            <?= $this->Paginator->prev('< ' . __('previous')) ?>
            <?= $this->Paginator->numbers() ?>
            <?= $this->Paginator->next(__('next') . ' >') ?>
            <?= $this->Paginator->last(__('last') . ' >>') ?>
        </ul>
        <p><?= $this->Paginator->counter(['format' => __('Page {{page}} of {{pages}}, showing {{current}} record(s) out of {{count}} total')]) ?></p>
    </div>
</div>
