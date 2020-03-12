<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Gamescore $gamescore
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Form->postLink(
                __('Delete'),
                ['action' => 'delete', $gamescore->Id],
                ['confirm' => __('Are you sure you want to delete # {0}?', $gamescore->Id)]
            )
        ?></li>
        <li><?= $this->Html->link(__('List Gamescore'), ['action' => 'index']) ?></li>
    </ul>
</nav>
<div class="gamescore form large-9 medium-8 columns content">
    <?= $this->Form->create($gamescore) ?>
    <fieldset>
        <legend><?= __('Edit Gamescore') ?></legend>
        <?php
            echo $this->Form->control('Score');
            echo $this->Form->control('Day');
        ?>
    </fieldset>
    <?= $this->Form->button(__('Submit')) ?>
    <?= $this->Form->end() ?>
</div>
