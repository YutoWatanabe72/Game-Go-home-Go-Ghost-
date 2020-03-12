<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Gamescore $gamescore
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Html->link(__('Edit Gamescore'), ['action' => 'edit', $gamescore->Id]) ?> </li>
        <li><?= $this->Form->postLink(__('Delete Gamescore'), ['action' => 'delete', $gamescore->Id], ['confirm' => __('Are you sure you want to delete # {0}?', $gamescore->Id)]) ?> </li>
        <li><?= $this->Html->link(__('List Gamescore'), ['action' => 'index']) ?> </li>
        <li><?= $this->Html->link(__('New Gamescore'), ['action' => 'add']) ?> </li>
    </ul>
</nav>
<div class="gamescore view large-9 medium-8 columns content">
    <h3><?= h($gamescore->Id) ?></h3>
    <table class="vertical-table">
        <tr>
            <th scope="row"><?= __('Id') ?></th>
            <td><?= $this->Number->format($gamescore->Id) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('Score') ?></th>
            <td><?= $this->Number->format($gamescore->Score) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('Day') ?></th>
            <td><?= h($gamescore->Day) ?></td>
        </tr>
    </table>
</div>
