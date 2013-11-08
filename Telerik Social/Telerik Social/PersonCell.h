//
//  PersonCell.h
//  Telerik Social
//
//  Created by Stanimir Karoserov on 07.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import <UIKit/UIKit.h>

@class PersonCell;

@protocol PersonCellDelegate <NSObject>

- (void)onEmail:(PersonCell *)cell;

@end

@interface PersonCell : UITableViewCell

@property (nonatomic, weak) id<PersonCellDelegate> delegate;

@property (nonatomic, strong) IBOutlet UIImageView* personImage;
@property (nonatomic, strong) IBOutlet UILabel* personName;
@property (nonatomic, strong) IBOutlet UILabel* personTeam;
@property (nonatomic, assign) NSUInteger index;

@end
