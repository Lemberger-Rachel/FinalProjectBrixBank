﻿using BrixBank.Data.Entities;
using BrixBank.Services.Interfaces;
using BrixBank.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrixBank.Data.Repositories
{
    public class LoanRequestRepository : ILoanRequestRepository
    {

        private readonly BrixBankContext _context;

        public LoanRequestRepository(BrixBankContext context)
        {
            _context = context;
        }
        public RuleNode BuidlTree(List<Rules> rules)
        {
            if (rules.Count == 1)
            {
                var ruleNode2 = new RuleNode();
                ruleNode2.rule = rules[0];
                return ruleNode2;
            }
            var ruleNode = new RuleNode();
            ruleNode.rule = new BaseRule();
            ruleNode.rule.Operator = "AND";
            ruleNode.Left = new RuleNode();
            ruleNode.Left.rule = rules[0];
            rules.RemoveAt(0);
            ruleNode.Right = BuidlTree(rules);
            return ruleNode;
        }

        public bool EvalRule(int dataValue, Rules rule)
        {
            switch (rule.Operator)
            {
                case ">=":
                    return dataValue >= rule.Output;
                case "<=":
                    return dataValue <= rule.Output;
                case "<":
                    return dataValue < rule.Output;
                case ">":
                    return dataValue > rule.Output;
                case "==":
                    return dataValue == rule.Output;
                default:
                    return false;
            }
        }
        public bool Eval(Dictionary<string, int> data, RuleNode root)
        {
            var rule = root.rule as Rules;
            if (rule != null)
            {
                return EvalRule(data[rule.Kind], rule);
            }
            else
            {
                return Eval(data, root.Left) && Eval(data, root.Right);
            }
        }
        public async Task<bool> Reqest(LoanRequestModel loanRequestModel)
        {
            try
            {
                var listRule = new List<Rules>();
                Customer customer = _context.Customers.FirstOrDefault(c => c.CustomerId == loanRequestModel.LoanSupplied);
                    foreach (var item in _context.Rules)
                    {
                    if (item.CustomerId2!=null&& customer.CustomerId == loanRequestModel.LoanSupplied){
                            listRule.Add(item);
                        }
                    }
                RuleNode treeRule = BuidlTree(listRule);
                return Eval(loanRequestModel.dictionaryData, treeRule);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
//try
//            {
//                var listRule =new List<Rules>();
//                //var listRuleCriterion = new Dictionary<string, object>();
//                var dictionary = new Dictionary<string, int>();
//                //list for criterion

//                //loanRequestModel.GetType().GetProperties().ToList().
//                //    ForEach(p => {
//                //    if (p.GetCustomAttribute<Criterion>() != null)
//                //        listRuleCriterion.Add(p.Name, p.GetValue(loanRequestModel));
//                //    });

//                Customer customer = _context.Customers.FirstOrDefault(c => c.CustomerId == loanRequestModel.LoanSupplied);
//                foreach (var item in _context.Rules)
//                {
//                    if (item.CustomerId2.CustomerId == loanRequestModel.LoanSupplied)
//                    {
//                        //dictionary.Add(item.Kind, dictionary[item.Kind]);
//                        listRule.Add(item);
//                    }
//                }
//                RuleNode tree = BuidlTree(listRule);
//                bool return1 = Eval(dictionary, tree);

//                return true;
//            }